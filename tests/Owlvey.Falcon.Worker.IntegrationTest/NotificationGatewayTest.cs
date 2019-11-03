using Owlvey.Falcon.Components;
using Owlvey.Falcon.Components.Gateways;
using Owlvey.Falcon.Worker.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Owlvey.Falcon.Worker.IntegrationTest
{
    public class NotificationGatewayTest
    {

        [Fact]
        public async Task SendNotification()
        {
            var gateway = new NotificationGateway(new ConfigurationComponent());
            List<NotificationEntity> notifications = new List<NotificationEntity>();

            var entity = new NotificationEntity();
            entity.AddWhom(new MemberEntity() { 
                 Email = "greg@test.com",
                 Name = "gregory valderrama",
                 SlackMember = "UFR3ZBD6Y"
            });

            entity.AddServiceReason(new ServiceEntity()
            {
                Availability = 0.98m,
                SLO = 0.99m,
                Name = "service test",
                Budget = -0.01m,
                Leaders = "greg@test.com"
            }, DateTime.Now, DateTime.Now);
            
            notifications.Add(entity);
            await gateway.SendNotifications(notifications);            
        }
    }
}
