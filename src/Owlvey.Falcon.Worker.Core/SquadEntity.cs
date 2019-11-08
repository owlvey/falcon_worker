using System;
using System.Collections.Generic;
using System.Linq;
namespace Owlvey.Falcon.Worker.Core
{
    public class SquadDetailEntity : SquadEntity {
        public class FeatureSquad
        {

            public string Service { get; set; }
            public string Product { get; set; }
            public decimal SLO { get; set; }
            public decimal Availability { get; set; }
            public decimal Points { get; set; }
            public string Name { get; set; }

        }
        public List<MemberEntity> Members { get; set; }
        public List<FeatureSquad> Features { get; set; }
       
        public decimal Points { get; set; }
        public string Leaders { get; set; }


        public string[] GetLeaders()
        {
            if (string.IsNullOrWhiteSpace(this.Leaders))
            {
                return new string[0];
            }
            else
            {
                var items = this.Leaders.Split(",");
                var leaders = items.Select(c => c.Trim()).ToList();
                foreach (var item in this.Members)
                {
                    leaders.Add(item.Email);
                }
                return leaders.Distinct().ToArray();
            }
        }

    }

    public class SquadEntity
    {

       
        public int Id { get; set; }
        public string Name { get; set; }
        
        
    }
}
