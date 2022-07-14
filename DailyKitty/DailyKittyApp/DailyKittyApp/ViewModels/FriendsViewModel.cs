using DailyKittyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DailyKittyApp.ViewModels
{
    internal class FriendsViewModel : BaseViewModel
    {
        public ObservableCollection<Friend> FriendCollection { get; set; }

        public FriendsViewModel() 
        {
            FriendCollection = new ObservableCollection<Friend>();
            FriendCollection.Add(new Friend { Name = "Fred" });
            FriendCollection.Add(new Friend { Name = "John" });
            FriendCollection.Add(new Friend { Name = "Anthony" });
            FriendCollection.Add(new Friend { Name = "Robin" });
        }

        public ICommand AddFriendCommand => new Command(AddFriend);
        void AddFriend()
        {
            Console.WriteLine("AddFriend binding works!");
        }

    }
}
