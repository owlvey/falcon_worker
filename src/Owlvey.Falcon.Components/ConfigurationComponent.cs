using System;
using System.Collections.Generic;
using System.Text;

namespace Owlvey.Falcon.Components
{
    public class ConfigurationComponent
    {
        public string OwlveyNofiticationApi {
            get {
                return "http://localhost:5000";
            }
        }
        public string OwlveyApi { 
            get {
                return "http://10.237.18.213:45001";
            } 
        }

        public string OwlveySite
        {
            get
            {
                return "http://10.237.18.213:45000";
            }
        }
        public string OwlveyIdentity
        {
            get
            {
                return "http://10.237.18.213:45002";
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
