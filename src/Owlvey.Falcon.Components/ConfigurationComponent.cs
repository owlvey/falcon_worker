using System;
using System.Collections.Generic;
using System.Text;

namespace Owlvey.Falcon.Components
{
    public class ConfigurationComponent
    {
        public ConfigurationComponent() {
            this.OwlveyNofiticationApi = Environment.GetEnvironmentVariable("owlvey_notification_api");
            if (string.IsNullOrWhiteSpace(this.OwlveyNofiticationApi))
            {
                this.OwlveyNofiticationApi = "http://localhost:50003";
            }

            this.OwlveyApi = Environment.GetEnvironmentVariable("owlvey_api");
            if (string.IsNullOrWhiteSpace(this.OwlveyApi))
            {
                this.OwlveyApi = "http://localhost:50001";
            }

            this.OwlveySite = Environment.GetEnvironmentVariable("owlvey_site");
            if (string.IsNullOrWhiteSpace(this.OwlveySite))
            {
                this.OwlveySite = "http://localhost:4200";
            }

            this.OwlveyIdentity = Environment.GetEnvironmentVariable("owlvey_identity");
            if (string.IsNullOrWhiteSpace(this.OwlveyIdentity))
            {
                this.OwlveyIdentity = "http://localhost:50000";
            }

            this.OwlveyClientId = Environment.GetEnvironmentVariable("owlvey_client_id");
            if (string.IsNullOrWhiteSpace(this.OwlveyClientId))
            {
                this.OwlveyClientId = "CF4A9ED44148438A99919FF285D8B48D";
            }
            this.OwlveySecretKey = Environment.GetEnvironmentVariable("owlvey_secret_key");
            if (string.IsNullOrWhiteSpace(this.OwlveySecretKey))
            {
                this.OwlveySecretKey = "0da45603-282a-4fa6-a20b-2d4c3f2a2127";
            }

        }
        public string OwlveyNofiticationApi { get; protected set; }
        public string OwlveyApi { get; protected set; }
        public string OwlveySite { get; protected set; }
        public string OwlveyIdentity { get; protected set; }        
        public string OwlveyClientId { get; protected set; }
        public string OwlveySecretKey { get; protected set; }        
    }
}
