using GreenHomeAdvisor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHomeAdvisor.Views.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public List<StatsMenuItem> items;

        public StatisticsPage()
        {
            InitializeComponent();
            SetItems();
            Title = "Consumption Statistics";
        }

        void SetItems()
        {
            items = new List<StatsMenuItem>();
            items.Add(new StatsMenuItem("January", "100"));
            items.Add(new StatsMenuItem("February", "200"));
            items.Add(new StatsMenuItem("March", "90"));
            items.Add(new StatsMenuItem("April", "110"));
            items.Add(new StatsMenuItem("May", "105"));
            items.Add(new StatsMenuItem("June", "95"));
            items.Add(new StatsMenuItem("July", "120"));
            items.Add(new StatsMenuItem("August", "117"));
            items.Add(new StatsMenuItem("October", "93"));
            items.Add(new StatsMenuItem("November", "89"));
            items.Add(new StatsMenuItem("December", "107"));
            ListView.ItemsSource = items;
        }

        async void MonthClicked(object sender, EventArgs e)
        {

            string month = ((Button)sender).Text;   //Month used for list traversal
            string consumption = "0";               //Month's consumption in kwH
            string header;                           //Used in display alert

            for (int i = 0; i < items.Count; i++)   //Search list for matching month
            {
                if (items[i].Month.Equals(month))
                {
                    consumption = items[i].Consumption;
                }
            }
            int usage = int.Parse(consumption);     //Convert to integer for math calculations

            header = month + " Consumption Statistics";

            await DisplayAlert(header, ConsumptionStats(month,usage),"Okay");
        }

        static string ConsumptionStats(string month, int consumption)               //Develops the full month statistics
        {
            double billRate = 0.12;    //Used for monthly bill conversion
            double greenRate = 1.22;   //Used for green house emissions     RATE OBTAINED FROM: https://carbonfund.org/how-we-calculate/
            double monthlyBill;    //Month bill total
            double greenHouse;     //Green house gas output

            //Calculation Base
            monthlyBill = consumption * billRate;
            greenHouse = consumption * greenRate;

            //String format
            string info = String.Format(month + " Consumption: {0} kwH \n", consumption);

            info += String.Format(month + " Bill Total: ${0} \n", monthlyBill);

            info += String.Format(month + " CO2 Emmisions: {0} lbs/kwH \n", greenHouse);

            return info;
        }
    }
}
