using System;
using System.Collections.Generic;
using System.Text;

namespace Owlvey.Falcon.Worker.Core
{
    public class ServiceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Availability { get; set; }
        public decimal SLO { get; set; }
        public string Leaders { get; set; }

        public decimal Budget { get; set; }

        public string[] GetLeaders() {
            if (string.IsNullOrWhiteSpace(this.Leaders))
            {
                return new string[0];
            }
            else {
                return this.Leaders.Split(",");
            }            
        }
    }
}
