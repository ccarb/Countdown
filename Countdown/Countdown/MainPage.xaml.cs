using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Countdown
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            UpdateCountdownList();
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
            UpdateCountdownList();
        }
        void UpdateCountdownList()
        {
            
            // Access or create DB
            var db = new SQLiteConnection(Constants.DatabasePath);
            if (db.Table<CountdownTable>().Count() != 0)
            {
                CountdownLayout.Children.Clear();
                var countdownRecords = db.Table<CountdownTable>();
                foreach (var record in countdownRecords)
                {
                    Frame countdownCard = new Frame
                    {
                        HeightRequest = 160,
                        WidthRequest = 300,
                        HorizontalOptions = LayoutOptions.Center,
                        BackgroundColor = Color.CornflowerBlue,
                        Content = new StackLayout
                        {
                            Children =
                        {
                            new Label
                            {
                                Text=record.Name,
                            },
                            new Label
                            {
                                Text=record.Description,
                            },
                            new Label
                            {
                                Text="Due " + record.Due.ToShortDateString() , FontSize=36,
                            },
                            new Label
                            {
                                Text="Created " + record.Created.ToLongDateString(),
                            }
                        }
                        }
                    };
                    CountdownLayout.Children.Add(countdownCard);
                }
            }
        }
    }
}
