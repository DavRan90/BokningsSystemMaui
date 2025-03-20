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
        public ObservableCollection<Models.BookingWithAdditionalInfo> BookingsWithExtras { get; set; }

        public ObservableCollection<Models.Session> Sessions { get; set; }

        public static List<Models.Session> Method(ObservableCollection<Session> sessions, DateTime date)
        {
            List<Session> sessionsOnDate = new List<Session>();
            
            foreach (var session in sessions)
            {
                if (session.Date == date)
                {
                    sessionsOnDate.Add(session);
                }
            }
            var _events = new EventCollection
            {
                //[new DateTime(2025, 3, 3)] = eventModels 
                [new DateTime(2025, 3, 3)] = sessionsOnDate
            };
            for (int i = 0; i < sessionsOnDate.Count; i++)
            {
                
                //eventModels.Add(new() { Id = sessionsOnDate[i].Id, Name = $"{sessionsOnDate[i].SessionName,-10} {"|",-3} {sessionsOnDate[i].TimeStart} - {sessionsOnDate[i].TimeEnd} ", Description = $"{20 - sessionsOnDate[i].SlotsBooked} platser kvar" });
                
                //if(sessionsOnDate[i].SlotsBooked >= 19)
                //{
                    
                //}
            }
            
            //new() { Name = $"{Sessions[0].SessionName, -10} {"|", -3} {Sessions[0].TimeStart} - {Sessions[0].TimeEnd} ", Description = $"{20 - Sessions[0].SlotsBooked} platser kvar" },

            return sessionsOnDate;
        }

        public BookPageViewModel()
        {
            //Sessions = new ObservableCollection<Models.Session>();
            List<Session> sessions = Db.GetAllSessions();
            Sessions = new ObservableCollection<Models.Session>(sessions);

            Events = new EventCollection
            {
                // First monday
                [new DateTime(2025, 3, 3)] = Method(Sessions, new DateTime(2025, 3, 3)),
                // Tuesday
                [new DateTime(2025, 3, 4)] = Method(Sessions, new DateTime(2025, 3, 4)),
                // Wednesday
                [new DateTime(2025, 3, 5)] = Method(Sessions, new DateTime(2025, 3, 5)),
                // ThursdayDateOnly     
                [new DateTime(2025, 3, 6)] = Method(Sessions, new DateTime(2025, 3, 6)),
                // Friday
                [new DateTime(2025, 3, 7)] = Method(Sessions, new DateTime(2025, 3, 7)),
                // Saturday

                // Sunday
                [new DateTime(2025, 3, 9)] = Method(Sessions, new DateTime(2025, 3, 9)),
            };

        }

        public static void AddEvents()
        {

            

        }
    }
}
