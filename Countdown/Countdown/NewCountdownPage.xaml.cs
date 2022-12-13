using SQLite;
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
            var db = new SQLiteConnection(Constants.DatabasePath);
            var newCountdown = new CountdownTable();
            newCountdown.Name = Name.Text;
            newCountdown.Description = Description.Text;
            newCountdown.Created = DateTime.Now;
            newCountdown.Due = DueDate.Date;
            db.Insert(newCountdown);
            await Navigation.PopModalAsync();
        }
    }
}