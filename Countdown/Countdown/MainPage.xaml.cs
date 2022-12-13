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
    public class CountdownListElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Created { get; set; }
        public string Due { get; set; }
        public int RemainingDays { get; set; }

        public CountdownListElement(int Id, string Name, string Description, DateTime Created, DateTime Due)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Created = Created.ToLongDateString() + ", " + Created.ToShortTimeString();
            this.Due = Due.ToShortDateString();
            this.RemainingDays = calculateRemainingDays();
        }

        public int calculateRemainingDays() { return (DateTime.Parse(Due)-DateTime.Now).Days; }
    }
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            UpdateCountdownList();


            List<CountdownListElement> countdownElements= new List<CountdownListElement>(db.Table<CountdownTable>().Count());
            foreach (CountdownTable elem in db.Table<CountdownTable>())
            {
                countdownElements.Add(new CountdownListElement(elem.Id, elem.Name, elem.Description, elem.Created, elem.Due));
            }

            CountdownLayout.ItemsSource = countdownElements;
        }
        int count = 0;
        SQLiteConnection db = new SQLiteConnection(Constants.DatabasePath);

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
            if (db.Table<CountdownTable>().Count() != 0)
            {
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
                    
                }
            }
        }
    }
}
