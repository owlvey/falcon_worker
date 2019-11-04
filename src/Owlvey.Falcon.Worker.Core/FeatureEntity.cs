using System;
using System.Collections.Generic;
using System.Text;

namespace Owlvey.Falcon.Worker.Core
{
    public class FeatureEntity
    {
        public string Name { get; set; }
        public decimal Availability { get; set; }
        public decimal Budget { get; set; }
        public decimal FeatureSlo { get; set; }
    }
}
