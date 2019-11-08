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

        public async Task<List<NotificationProductEntity>> BuildProductLeadersNofifications(DateTime start, DateTime end) {
            var result = new List<NotificationProductEntity>();
            var customers = await this.owlveyGateway.GetOrganizationsWithProducts();
            var members = await this.owlveyGateway.GetMembers();

            foreach (var customer in customers)
            {
                foreach (var product in customer.Products)
                {
                    var leaders = product.GetLeaders();
                    if (leaders.Length > 0)
                    {
                        var dashboard = await this.owlveyGateway.GetProductDashboardByProduct(product.Id, start, end);

                        var notification = new NotificationProductEntity();
                        var owners = members.Where(c => leaders.Contains(c.Email)).ToList();
                        foreach (var owner in owners)
                        {
                            notification.AddWhom(owner);
                        }
                        notification.Load(customer, product, dashboard, start, end);
                        result.Add(notification);
                    }   
                }
            }

            return result;
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

        public async Task<List<NotificationSquadEntity>> BuildSquadMembersNotifications(DateTime start, DateTime end) {
            var result = new List<NotificationSquadEntity>();
            var customers = await this.owlveyGateway.GetOrganizationsWithProducts();
            var members = await this.owlveyGateway.GetMembers();

            foreach (var customer in customers)
            {
                var squads = await this.owlveyGateway.GetSquads(customer.Id);

                foreach (var squad in squads)
                {
                    var squadDetail = await this.owlveyGateway.GetSquadDetail(squad.Id, start, end);
                    var leaders = squadDetail.GetLeaders();
                    if (leaders.Length > 0)
                    {
                        var notification = new NotificationSquadEntity();
                        var owners = members.Where(c => leaders.Contains(c.Email)).ToList();
                        foreach (var owner in owners)
                        {
                            notification.AddWhom(owner);
                        }
                        notification.Load(customer, squadDetail, start, end);
                        result.Add(notification);
                    }
                }
            }
            return result;
        }
    }
}
