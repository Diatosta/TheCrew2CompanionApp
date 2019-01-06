using System;
using TheCrew2CompanionApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheCrew2CompanionApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        private int totalVehiclesCostBucks = 0;
        private int purchasedVehiclesCostBucks = 0;
        private int totalVehiclesCostCredits = 0;
        private int purchasedVehiclesCostCredits = 0;
        private int totalVehiclesCount = 0;
        private int purchasedVehiclesCount = 0;

        public AboutPage()
        {
            InitializeComponent();

            foreach(Vehicle vehicle in LoadedData.Vehicles)
            {
                totalVehiclesCostBucks += vehicle.CostBucks;
                totalVehiclesCostCredits += vehicle.CostCredits;

                totalVehiclesCount++;

                if (vehicle.HasBeenPurchased)
                {
                    purchasedVehiclesCostBucks += vehicle.CostBucks;
                    purchasedVehiclesCostCredits += vehicle.CostCredits;

                    purchasedVehiclesCount++;
                }
            }

            int remainingCostBucks = totalVehiclesCostBucks - purchasedVehiclesCostBucks;
            int remainingCostCredits = totalVehiclesCostCredits - purchasedVehiclesCostCredits;
            int remainingCostBucksDiscount = (int)(remainingCostBucks - (remainingCostBucks * 0.2f));
            int remainingCostCreditsDiscount = (int)(remainingCostCredits - (remainingCostCredits * 0.2f));

            CarsBoughtLabel.Text = purchasedVehiclesCount.ToString() + "/" + totalVehiclesCount.ToString();
            RemainingValueLabelBucks.Text = String.Format("{0:N0}B", remainingCostBucks);
            RemainingValueLabelBucksDiscount.Text = String.Format("{0:N0}B", remainingCostBucksDiscount);
            RemainingValueLabelCredits.Text = String.Format("{0:N0}CC", remainingCostCredits);
            RemainingValueLabelCreditsDiscount.Text = String.Format("{0:N0}CC", remainingCostCreditsDiscount);
        }
    }
}