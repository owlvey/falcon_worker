using System;
using System.Collections.Generic;
using System.Text;

namespace Owlvey.Falcon.Worker.Core
{
    public class MemberEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public string SlackMember { get; set; }
    }
}
