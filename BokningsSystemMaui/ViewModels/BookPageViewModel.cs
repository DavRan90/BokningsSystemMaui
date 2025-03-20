using BokningsSystemMaui.Models;
using Plugin.Maui.Calendar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.ViewModels
{
    class BookPageViewModel
    {
        public EventCollection Events { get; set; }
        public ObservableCollection<Models.Session> Sessions { get; set; }

        public static List<Models.Session> SessionList(ObservableCollection<Session> sessions, DateTime date)
        {
            List<Session> sessionsOnDate = new List<Session>();
            
            foreach (var session in sessions)
            {
                if (session.Date == date)
                {
                    sessionsOnDate.Add(session);
                }
            }
            return sessionsOnDate;
        }

        public BookPageViewModel()
        {
            List<Session> sessions = Db.GetAllSessions();
            Sessions = new ObservableCollection<Models.Session>(sessions);
            Events = new EventCollection();
            
            foreach(var session in sessions)
            {
                if(!Events.Keys.Contains(session.Date))
                {
                    Events.Add(session.Date, SessionList(Sessions, session.Date));
                }
            }
        }
    }
}
