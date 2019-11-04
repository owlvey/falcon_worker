using System;
using System.Collections.Generic;
using System.Text;

namespace Owlvey.Falcon.Worker.Core
{

    public class NotificationWhomEntity { 
        public string name { get; set; }
        public string email { get; set; }
        public string slack_member { get; set; }
    }
    public class NotificationBase {
        public List<NotificationWhomEntity> whom { get; set; } = new List<NotificationWhomEntity>();
        public List<string> references { get; set; } = new List<string>();
        public void AddReference(string reference)
        {
            this.references.Add(reference);
        }
        public void AddWhom(MemberEntity entity)
        {
            this.whom.Add(new NotificationWhomEntity()
            {
                name = entity.Email,
                email = entity.Email,
                slack_member = entity.SlackMember
            });
        }
    }
    public class NotificationEntity: NotificationBase
    {
        public int emotion { get; set; } = 3;
        public string action { get; set; } = "alert";
        
        public List<string> what { get; set; } = new List<string>();
        public List<string> where { get; set; } = new List<string>();
        public List<string> when { get; set; } = new List<string>();
        public List<string> why { get; set; } = new List<string>();
   

        public void AddServiceReason(ServiceEntity service, DateTime start, DateTime end) {
            if (service.Budget < 0)
            {
                this.emotion = 2;
                this.AddWhat(service);
                this.AddWhere(service);
                this.AddWhen(start, end);
                this.AddWhy(service);
            }
            else
            {
                this.emotion = 5;
            }
        }

        public void AddWhat(ServiceEntity service) {
            var message = string.Format("SLO {0}, current availability is {1} ", service.SLO, service.Availability);
            this.what.Add(message);
        }
        public void AddWhen(DateTime start, DateTime end)
        {
            string message = string.Format("{0} - {1}", start.ToShortDateString(), end.ToShortDateString());
            this.when.Add(message);
        }
        public void AddWhere(ServiceEntity  service)
        {
            string message = string.Format("{0}", service.Name);
            this.where.Add(message);
        }

        public void AddWhy(ServiceEntity service)
        {
            string message = string.Format("Features in {0}", service.Name);
            this.why.Add(message);
        }
      
    }
}
