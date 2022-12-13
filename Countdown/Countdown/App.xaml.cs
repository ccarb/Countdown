using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;

namespace Countdown
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Access or create DB
            var db = new SQLiteConnection(Constants.DatabasePath);

            db.CreateTable<CountdownTable>();
            // This is for testing only, delete for prod
            if (db.Table<CountdownTable>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var newCountdown = new CountdownTable();
                newCountdown.Name = "Example";
                newCountdown.Description = "A hardcoded example for testing purposes";
                newCountdown.Created = DateTime.Now;
                newCountdown.Due = DateTime.Now;
                newCountdown.Due.AddDays(3);
                db.Insert(newCountdown);
            }

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
