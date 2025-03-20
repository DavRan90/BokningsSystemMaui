using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.Models
{
    public class Session
    {
        private static readonly Session currentSession = new Session();
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public int SessionType { get; set; }
        public int SlotsBooked { get; set; }
        public int MaxSlots { get; set; }

        public static Session GetCurrentSession()
        {
            return currentSession;
        }
        public static void SetCurrentSession(Session session)
        {
            currentSession.Id = session.Id;
            currentSession.Name = session.Name;
            currentSession.Date = session.Date;
            currentSession.TimeStart = session.TimeStart;
            currentSession.TimeEnd = session.TimeEnd;
            currentSession.SessionType = session.SessionType;
            currentSession.SlotsBooked = session.SlotsBooked;
            currentSession.MaxSlots = session.MaxSlots;
        }
    }
}
