using BokningsSystemMaui.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.ViewModels
{
    public class NotificationPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Session> _sessions;

        public ObservableCollection<Session> Sessions
        {
            get { return _sessions; }
            set
            {
                _sessions = value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged()
        {
            // ? null?
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sessions"));
        }
        public NotificationPageViewModel()
        {
            var userSessions = Db.GetListOfSessionsWithNotifications(User.GetUser().Id);
            Sessions = new ObservableCollection<Session>(userSessions);
        }

        //private async void LoadSessionsAsync()
        //{
        //    var sessions = await GetSessionsFromDbAsync();

        //    foreach (var session in sessions)
        //    {
        //        Sessions.Add(session);
        //    }

        //}
        //private async void GetSessionsFromDbAsync()
        //{
        //    User currentUser = User.GetUser();
        //    List<Session> sessions = await Db.GetListOfSessionsWithNotifications(User.GetUser().Id);
        //    Sessions = new ObservableCollection<Session>(sessions);
        //    //await Task.Delay(3000);
        //    //return sessions;
        //}
    }
}
