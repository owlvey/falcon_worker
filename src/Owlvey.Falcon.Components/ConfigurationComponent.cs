using System;
using System.Collections.Generic;
using System.Text;

namespace Owlvey.Falcon.Components
{
    public class ConfigurationComponent
    {
        public string OwlveyNofiticationApi {
            get {
                return "http://127.0.0.1:5000";
            }
        }
        public string OwlveyApi { 
            get {
                return "http://localhost:50001";
            } 
        }

        public string OwlveySite
        {
            get
            {
                return "http://localhost:4200";
            }
        }
        public string OwlveyIdentity
        {
            get
            {
                return "http://localhost:50000";
            }
        }
        public string OwlveyClientId {
            get {
                return "CF4A9ED44148438A99919FF285D8B48D";
            }
        }
        public string OwlveySecretKey
        {
            get
            {
                return "0da45603-282a-4fa6-a20b-2d4c3f2a2127";
            }
        }
    }
}
