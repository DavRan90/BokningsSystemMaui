using BokningsSystemMaui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.ViewModels
{
    public class NotificationPageViewModel
    {
        public ObservableCollection<Notification> Notifications { get; set; }
        public ObservableCollection<SessionNotifications> SessionNotifications { get; set; }
        public ObservableCollection<Session> Sessions { get; set; }
        public NotificationPageViewModel()
        {
            var notifications = Db.GetCurrentUserNotifications(User.GetUser().Id);
            Notifications = new ObservableCollection<Notification>(notifications);
            var sessions = Db.GetListOfSessionsWithNotifications();
            SessionNotifications = new ObservableCollection<SessionNotifications>(sessions);

            var userSessions = Db.GetListOfSessionsWithNotifications(User.GetUser().Id);
            Sessions = new ObservableCollection<Session>(userSessions);
        }
    }
}
