using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Countdown
{
    public partial class NewCountdownPage : ContentPage
    {
        public NewCountdownPage()
        {
            InitializeComponent();
        }
        async void CreateCountdown(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}