using System;
using System.Collections.Generic;

namespace Owlvey.Falcon.Worker.Core
{
    public class ProductDashboardEntity
    {
        public ProductEntity Product { get; set; }
        public class Stats {
            public int Count { get; set; }
            public decimal Min { get; set; }
            public decimal Max { get; set; }
            public decimal Mean { get; set; }
        }

        public class Service {
            public decimal Availability { get; set; }
            public decimal Budget { get; set; }
            public decimal Slo { get; set; }
            public string Name { get; set; }
        }

        public decimal FeaturesCoverage { get; set; }
        public decimal SloProportion { get; set; }
        public int SourceTotal { get; set; }
        public Stats ServicesStats { get; set; }
        public List<Service> Services { get; set; }
        
    }
}
