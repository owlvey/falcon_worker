using System;
using System.Collections.Generic;
using System.Text;

namespace Owlvey.Falcon.Worker.Core
{
    public class AccessToken
    {        
        public AccessToken() { }
        public DateTime On { get; set; }
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }

        public string BearerToken() {
            return "Bearer " + this.access_token;
        }

        public bool Expire(DateTime target) {
            return On.AddSeconds(this.expires_in + 10) > target;
        }
    }
}
