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

        public async Task<List<NotificationEntity>> BuildServiceLeadersNotifications(DateTime start, DateTime end) {
            var result = new List<NotificationEntity>();

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

                            var notification = new NotificationEntity();
                            var owners = members.Where(c => leaders.Contains(c.Email)).ToList();
                            foreach (var owner in owners)
                            {
                                notification.AddWhom(owner);                                
                            }
                            notification.AddServiceReason(service, start, end);                            
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
