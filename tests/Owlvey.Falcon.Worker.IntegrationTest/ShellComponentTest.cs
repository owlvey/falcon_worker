using Owlvey.Falcon.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Owlvey.Falcon.Worker.IntegrationTest
{
    public class ShellComponentTest
    {
        [Fact]
        public async Task NotifyServiceLeaders()
        {
            var owlvey = new ShellComponent();
            await owlvey.NotifyAvailabilityServiceLeaders(DateTime.Now);                        
        }

        [Fact]
        public async Task NotifyProductLeaders()
        {
            var owlvey = new ShellComponent();
            await owlvey.NotifyAvailablityProductLeaders(DateTime.Now);
        }
        [Fact]
        public async Task NotifySquadMembers() {
            var owlvey = new ShellComponent();
            await owlvey.NotifyAvailablitySquads(DateTime.Now); 
        }
    }
}
