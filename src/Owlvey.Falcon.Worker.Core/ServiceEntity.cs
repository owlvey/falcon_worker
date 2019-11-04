using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public string Group { get; set; }
        public decimal FeatureSlo { get; set; }

        public List<FeatureEntity> Features { get; set; }

        public string[] GetLeaders() {
            if (string.IsNullOrWhiteSpace(this.Leaders))
            {
                return new string[0];
            }
            else {
                var items = this.Leaders.Split(",");
                return items.Select(c => c.Trim()).ToArray();                
            }            
        }
    }
}
