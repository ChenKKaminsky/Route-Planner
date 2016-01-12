using RoutePlanner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.BLL.Interfaces
{
    public interface INotificationService
    {
        void SendEmailNotification(MailingList mailingList);
    }
}
