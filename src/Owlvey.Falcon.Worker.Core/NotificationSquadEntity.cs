
using System;
using System.Collections.Generic;

namespace Owlvey.Falcon.Worker.Core
{
    public class NotificationSquadEntity : NotificationBase
    {
        public class Feature {
            public string product { get; set; }
            public string service { get; set; }
            public decimal slo { get; set; }
            public decimal availability { get; set; }
            public string feature { get; set; }
            public decimal points { get; set; }
        }

        public string organization { get; set; }
        public string squad { get; set; }
        public decimal points { get; set; }

        public string start { get; set; }
        public string end { get; set; }

        public List<Feature> features { get; set; } = new List<Feature>();

        public void Load(OrganizationEntity organization,
            SquadDetailEntity entity,
            DateTime start, DateTime end)
        {
            this.start = start.ToString("o");
            this.end = end.ToString("o");
            this.organization = organization.Name;
            
            this.squad = entity.Name;
            this.points = entity.Points;

            foreach (var feature in entity.Features)
            {
                this.features.Add(new Feature() {
                     product = feature.Product,
                     service = feature.Service,
                     feature = feature.Name,
                     slo = feature.SLO,
                     availability = feature.Availability,
                     points = feature.Points
                });


            }

        }
    }
}