using DailyKittyApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DailyKittyApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}