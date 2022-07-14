using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyKittyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCatsPage : ContentPage
    {
        public MyCatsPage()
        {
            InitializeComponent();
        }
    }
}