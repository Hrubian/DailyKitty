using DailyKittyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DailyKittyApp.ViewModels
{
    internal class MyCatsViewModel : BaseViewModel
    {
        public ObservableCollection<Cat> CatCollection { get; set; }

        public MyCatsViewModel()
        {
            CatCollection = new ObservableCollection<Cat>();
            CatCollection.Add(new Cat
            {
                Name = "Cindy",
                BirthDate = DateTime.Now,
                Description = "little furry friend...",
            });
            CatCollection.Add(new Cat
            {
                Name = "Sad Antonio",
                BirthDate = DateTime.Now,
                Description = "soo sad...",
            });
            CatCollection.Add(new Cat
            {
                Name = "Kasiopea",
                BirthDate = DateTime.Now,
                Description = "oh hell...",
            });
        }

        public ICommand GoToCatCommand => new Command(GoToCat);
        public void GoToCat(object cat)
        {
            Console.WriteLine("Visiting cat " + (cat as Cat).Name);
        }
    }
}
