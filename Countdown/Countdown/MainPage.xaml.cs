using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Countdown
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        int count = 0;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            count++;
        }

        void GoToCreditsView(object sender, System.EventArgs e)
        {
            count++;
        }
        async void AddNewCountdown(object sender, System.EventArgs e)
        {
            var NewCountdownPage = new NewCountdownPage();
            await Navigation.PushModalAsync(NewCountdownPage);
        }
    }
}
