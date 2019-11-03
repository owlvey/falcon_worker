using System;
using System.Collections.Generic;
using System.Text;

namespace Owlvey.Falcon.Worker.Core
{
    public class OrganizationEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
