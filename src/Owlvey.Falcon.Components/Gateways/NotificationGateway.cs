using Newtonsoft.Json;
using Owlvey.Falcon.Worker.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Owlvey.Falcon.Components.Gateways
{
    public class NotificationGateway
    {
        private ConfigurationComponent configurationComponent { get; set; }        
        public NotificationGateway(ConfigurationComponent configurationComponent)
        {
            this.configurationComponent = configurationComponent;
        }
        public async Task SendNotifications(List<NotificationEntity> notifications) {
            foreach (var notification in notifications)
            {
                await this.SendNotification(notification);                
            }
        }
        public async Task SendNotification(NotificationEntity notification)
        {
            HttpClient client = new HttpClient();
            string url = this.configurationComponent.OwlveyNofiticationApi + "/notifications";
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(notification)
                , Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            if (!response.IsSuccessStatusCode) {
                throw new ApplicationException("notification fails " + response.StatusCode.ToString());
            }
        }

    }
}
