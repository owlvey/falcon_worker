using System;
using System.Collections.Generic;

namespace Owlvey.Falcon.Worker.Core
{    
    public class NotificationProductEntity : NotificationBase
    {
        public string name { get; set; }
        public decimal proportion { get; set; }

        public string start { get; set; }
        public string end { get; set; }

        public int requests { get; set; }
        public decimal feature_coverage { get; set; }

        public decimal min { get; set; }
        public decimal max { get; set; }
        public decimal mean { get; set; }

        public class Service {
            public string name { get; set; }
            public decimal availability { get; set; }
            public decimal slo { get; set; }
            public decimal budget { get; set; }
        }

        public List<Service> services { get; set; } = new List<Service>();

        public void Load(ProductEntity product, ProductDashboardEntity entity, DateTime start, DateTime end) {

            this.name = product.Name;
            this.proportion = entity.SloProportion;
            this.requests = entity.SourceTotal;
            this.feature_coverage = entity.FeaturesCoverage;
            this.min = entity.ServicesStats.Min;
            this.max = entity.ServicesStats.Max;
            this.mean = entity.ServicesStats.Mean;                       
            this.start = start.ToString("o");
            this.end = end.ToString("o");

            foreach (var item in entity.Services)
            {
                this.services.Add(new Service()
                {
                    name = item.Name,
                    availability = item.Availability,
                    budget = item.Budget,
                    slo = item.Slo
                });                
            }
        }
    }
}
