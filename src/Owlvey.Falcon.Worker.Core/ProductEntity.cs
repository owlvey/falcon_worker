using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Owlvey.Falcon.Worker.Core
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
                return items.Select(c => c.Trim()).ToArray();
            }
        }

    }
}
