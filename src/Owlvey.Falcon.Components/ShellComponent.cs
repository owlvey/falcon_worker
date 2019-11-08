using Owlvey.Falcon.Components.Gateways;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Owlvey.Falcon.Components
{
    public class ShellComponent
    {
        private ConfigurationComponent ConfigurationComponent { get; set; }
        private AvailabilityGuardComponent AvailabilityGuardComponent { get; set; }
        private NotificationGateway NotificationGateway;

        private OwlveyGateway OwlveyGateway;
        public ShellComponent() {
            this.ConfigurationComponent = new ConfigurationComponent();
            this.OwlveyGateway = new OwlveyGateway(ConfigurationComponent);
            this.NotificationGateway = new NotificationGateway(ConfigurationComponent);
            this.AvailabilityGuardComponent = new AvailabilityGuardComponent(this.OwlveyGateway);
        }

        public void NotifyAvailabilitySquadLeaders() { 

        }
        public async Task NotifyAvailabilityServiceLeaders(DateTime target)
        {
            DateTime start = target.Date.AddDays(-30);
            DateTime end = target.Date;
            var notifications = await this.AvailabilityGuardComponent.BuildServiceLeadersNotifications(start, end);

            foreach (var item in notifications)
            {
                item.AddReference(this.ConfigurationComponent.OwlveySite);
            }

            await this.NotificationGateway.SendServiceNotifications(notifications); 
        }

        public async Task NotifyAvailablityProductLeaders(DateTime target) {
            DateTime start = target.Date.AddDays(-30);
            DateTime end = target.Date;
            var notifications = await this.AvailabilityGuardComponent.BuildProductLeadersNofifications(start, end);

            foreach (var item in notifications)
            {
                item.AddReference(this.ConfigurationComponent.OwlveySite);
            }

            await this.NotificationGateway.SendProductNotifications(notifications);

        }
        public async Task NotifyAvailablitySquads(DateTime target)
        {
            DateTime start = target.Date.AddDays(-30);
            DateTime end = target.Date;
            var notifications = await this.AvailabilityGuardComponent.BuildSquadMembersNotifications(start, end);

            foreach (var item in notifications)
            {
                item.AddReference(this.ConfigurationComponent.OwlveySite);

                foreach (var member in item.whom)
                {
                      member.slack_member = "UFR3ZBD6Y";
                }
            }


            await this.NotificationGateway.SendSquadNotifications(notifications);

        }
    }
}
