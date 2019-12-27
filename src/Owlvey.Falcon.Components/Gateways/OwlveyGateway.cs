using Newtonsoft.Json;
using Owlvey.Falcon.Worker.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Owlvey.Falcon.Components.Gateways
{
    public class OwlveyGateway
    {
        public ConfigurationComponent configurationComponent { get; set; }
        public AccessToken AccessToken { get; set; }
        public OwlveyGateway(ConfigurationComponent configurationComponent)
        {
            this.configurationComponent = configurationComponent;
        }

        public async Task EnsureToken() {
            if (AccessToken == null) await this.GenerateToken();
            if (AccessToken.Expire(DateTime.Now)) await this.GenerateToken();
        }
        public async Task GenerateToken() {
            
            var client = new HttpClient();
            var data = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials",
                ["scope"] = "api",
                ["client_id"] = this.configurationComponent.OwlveyClientId,
                ["client_secret"] = this.configurationComponent.OwlveySecretKey,
            };

            var content = new FormUrlEncodedContent(data);
            var response = await client.PostAsync(this.configurationComponent.OwlveyIdentity + "/connect/token", content);                        
            if (!response.IsSuccessStatusCode) {
                throw new ApplicationException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsStringAsync();
            this.AccessToken = JsonConvert.DeserializeObject<AccessToken>(result);
            this.AccessToken.On = DateTime.Now;
        }

        private async Task<T> Get<T>(string url) {
            await this.EnsureToken();
            HttpClient client = new HttpClient();            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken.access_token);
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(string.Format("{0}, message: {1}", url, response.StatusCode.ToString()));
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
        public async Task<List<OrganizationEntity>> GetOrganizationsWithProducts() {                        
            string url = this.configurationComponent.OwlveyApi + "/customers";
            var customers = await this.Get<List<OrganizationEntity>>(url); 
            return customers;
        }

        public async Task<List<MemberEntity>> GetMembers() {
            string url = this.configurationComponent.OwlveyApi + "/users";
            var members = await this.Get<List<MemberEntity>>(url);
            return members;
        }

        public async Task<ProductDashboardEntity> GetProductDashboardByProduct(int productId, DateTime start, DateTime end)
        {            
            string url = this.configurationComponent.OwlveyApi +
                    string.Format("/products/{0}/dashboard?start={1}&end={2}", productId,
                    start.ToString("o"), end.ToString("o"));            
            var members = await this.Get<ProductDashboardEntity>(url);
            return members;
        }

        public async Task<List<ServiceEntity>> GetServicesByProduct(int productId, DateTime start, DateTime end) {
            //2019-10-04T13:38:58.732Z
            //2019-08-05T14:47:32.0327258Z            
            string url = this.configurationComponent.OwlveyApi  + 
                    string.Format("/services?productId={0}&start={1}&end={2}", productId, 
                    start.ToString("o"), end.ToString("o"));

            var services = await this.Get<List<ServiceEntity>>(url);
            return services;
        }
        public async Task<ServiceEntity> GetServiceDetail(int serviceId, DateTime start, DateTime end) {
            string url = this.configurationComponent.OwlveyApi +
                        string.Format("/services/{0}?start={1}&end={2}", serviceId,
                        start.ToString("o"), end.ToString("o"));

            var services = await this.Get<ServiceEntity>(url);
            return services;
        }


        public async Task<List<SquadEntity>> GetSquads(int customerId) {
            string url = this.configurationComponent.OwlveyApi +
                        string.Format("/squads?customerId={0}", customerId);

            var squads = await this.Get<List<SquadEntity>>(url);

            return squads;
        }

        public async Task<SquadDetailEntity> GetSquadDetail(int squadId, DateTime start, DateTime end)
        {
            string url = this.configurationComponent.OwlveyApi +
                string.Format("/squads/{0}?start={1}&end={2}", squadId, start.ToString("o"), end.ToString("o"));

            var squads = await this.Get<SquadDetailEntity>(url);

            return squads;
        }

    }
}
