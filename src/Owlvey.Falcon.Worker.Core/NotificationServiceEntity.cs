using System;
using System.Collections.Generic;
using System.Text;

namespace Owlvey.Falcon.Worker.Core
{
    public class NotificationServiceEntity: NotificationBase
    {
        public class Service { 
            public string name { get; set; }
            public decimal slo { get; set; }
            public decimal availability { get; set; }
            public decimal budget { get; set; }
            public decimal feature_slo { get; set; }
        }
        public class Feature {
            public string name { get; set; }            
            public decimal availability { get; set; }
            public decimal budget { get; set; }
            public decimal feature_slo { get; set; }
        }
        public string start { get; set; }
        public string end { get; set; }
        public Service service { get; set; }

        public List<Feature> features { get; set; } = new List<Feature>();

        public void Load(ServiceEntity entity, DateTime start, DateTime end) {
            this.service = new Service();
            service.name = entity.Name;
            service.slo = entity.SLO;
            service.availability = entity.Availability;
            service.budget = entity.Budget;
            service.feature_slo = entity.FeatureSlo;
            this.start = start.ToString("o");
            this.end = end.ToString("o");

            foreach (var item in entity.Features)
            {
                this.features.Add(new Feature() { 
                     availability = item.Availability,
                     budget = item.Budget,
                     feature_slo = item.FeatureSlo,
                     name = item.Name
                });
            }

        }
    }
}
