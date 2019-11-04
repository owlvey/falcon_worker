using Owlvey.Falcon.Components.Gateways;
using Owlvey.Falcon.Worker.Core;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Owlvey.Falcon.Components
{
    public class AvailabilityGuardComponent
    {
        private OwlveyGateway owlveyGateway;
        public AvailabilityGuardComponent(OwlveyGateway owlveyGateway) {
            this.owlveyGateway = owlveyGateway;
        }

        public async Task<List<NotificationServiceEntity>> BuildServiceLeadersNotifications(DateTime start, DateTime end) {
            var result = new List<NotificationServiceEntity>();

            var customers = await this.owlveyGateway.GetOrganizationsWithProducts();
            var members = await this.owlveyGateway.GetMembers();
            foreach (var customer in customers)
            {
                foreach (var product in customer.Products)
                {
                    var services = await this.owlveyGateway.GetServicesByProduct(product.Id, start, end);

                    foreach (var service in services)
                    {                        
                        var leaders = service.GetLeaders();
                        if (leaders.Length > 0) {

                            service.Features = (await this.owlveyGateway.GetServiceDetail(service.Id, start, end)).Features;

                            var notification = new NotificationServiceEntity();
                            var owners = members.Where(c => leaders.Contains(c.Email)).ToList();
                            foreach (var owner in owners)
                            {
                                notification.AddWhom(owner);                                
                            }
                            notification.Load(service, start, end);                            
                            result.Add(notification);                            
                        }
                    }                    
                }                
            }
            return result;
        }

        public List<NotificationEntity> BuildSquadMembersNotifications() {
            var result = new List<NotificationEntity>();

            var customers = this.owlveyGateway.GetOrganizationsWithProducts();            


            return result;
        }

    }
}
