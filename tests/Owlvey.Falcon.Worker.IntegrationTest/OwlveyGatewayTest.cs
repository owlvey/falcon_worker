using Owlvey.Falcon.Components;
using Owlvey.Falcon.Components.Gateways;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Owlvey.Falcon.Worker.IntegrationTest
{
    public class OwlveyGatewayTest
    {
        [Fact]
        public async Task GenerateTokenSuccess()
        {
            var owlvey = new OwlveyGateway(new ConfigurationComponent());
            await owlvey.GenerateToken();
            Assert.NotNull(owlvey.AccessToken);
        }

        [Fact]
        public async Task GetCustomersSuccess()
        {
            var owlvey = new OwlveyGateway(new ConfigurationComponent());
            var customers = await owlvey.GetOrganizationsWithProducts();
            Assert.NotNull(customers);
        }

        [Fact]
        public async Task GetCustomersAndServicesSuccess()
        {
            DateTime start = DateTime.Now.Date.AddDays(-90);
            DateTime end = DateTime.Now.Date;
            var owlvey = new OwlveyGateway(new ConfigurationComponent());
            var customers = await owlvey.GetOrganizationsWithProducts();
            foreach (var item in customers)
            {
                foreach (var product in item.Products)
                {
                    var services = await owlvey.GetServicesByProduct(product.Id, start, end);
                }
            }
            Assert.NotNull(customers);
        }

        [Fact]
        public async Task GetMembersSuccess()
        {
            var owlvey = new OwlveyGateway(new ConfigurationComponent());
            var members = await owlvey.GetMembers();
            Assert.NotNull(members);
        }

        [Fact]
        public async Task GetProductDashboardSuccess()
        {
            DateTime start = DateTime.Now.Date.AddDays(-15);
            DateTime end = DateTime.Now.Date;
            var owlvey = new OwlveyGateway(new ConfigurationComponent());
            var organizations = await owlvey.GetOrganizationsWithProducts();
            foreach (var item in organizations)
            {
                foreach (var product in item.Products)
                {
                    var result = await owlvey.GetProductDashboardByProduct(product.Id, start, end);                    
                    Assert.NotNull(result);
                }
            }            
        }
    }
}
