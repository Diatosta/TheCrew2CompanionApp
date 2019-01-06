using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheCrew2CompanionApp.Interfaces;
using TheCrew2CompanionApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static TheCrew2CompanionApp.Models.VehicleCategoriesEnum;
using static TheCrew2CompanionApp.Models.VehicleCategory;

namespace TheCrew2CompanionApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VehicleDetailsPage : ContentPage
	{
        private Vehicle vehicle;

		public VehicleDetailsPage (Vehicle vehicle)
		{
            this.vehicle = vehicle;

            InitializeComponent ();

            BindingContext = this.vehicle;

            HasBeenPurchasedSwitch.IsToggled = this.vehicle.HasBeenPurchased;

            if (this.vehicle.CostBucks > 0)
            {
                CostBucksLabel.Text = String.Format("Cost(Bucks): {0:N0}B", this.vehicle.CostBucks);
            }
            else
            {
                CostBucksLabel.Text = "Cost(Bucks): N/A";
            }

            if (this.vehicle.CostCredits > 0)
            {
                CostCreditsLabel.Text = String.Format("Cost(Credits): {0:N0}CC", this.vehicle.CostBucks);
            }
            else
            {
                CostCreditsLabel.Text = "Cost(Credits): N/A";
            }

            UnlockLevelLabel.Text = "Unlock level: " + (this.vehicle.LevelToUnlock > 0 ? this.vehicle.LevelToUnlock.ToString() : "N/A");

            TopSpeedKmhLabel.Text = "Top speed (Kmh): " + (this.vehicle.TopSpeedKMh > 0 ? this.vehicle.TopSpeedKMh.ToString() : "N/A");

            TopSpeedMphLabel.Text = "Top speed (Mph): " + (this.vehicle.TopSpeedKMh > 0 ? (this.vehicle.TopSpeedKMh / 1.609f).ToString() : "N/A");

            PowerBHPLabel.Text = "Bhp: " + (this.vehicle.PowerBHP > 0 ? this.vehicle.PowerBHP.ToString() : "N/A");
            
            VehicleCategory currentVehicleCategory = LoadedData.VehicleCategories[vehicle.VehicleCategory.VehicleActualTypes];

            RatingLabel.Text = "Rating: " + this.vehicle.Rating.ToString() + "/" + currentVehicleCategory.MaximumRating.ToString();

            VehicleCategories category = this.vehicle.VehicleActualCategory;
            string categoryString = category.GetDescription();

            VehicleTypeOverall types = this.vehicle.VehicleActualTypeOverall;
            string typesString = types.GetDescription();

            CategoryLabel.Text = "Category: " + categoryString + "/" + currentVehicleCategory.Name + "/" + typesString;

            SeasonPassExclusiveLabel.Text = "Season pass exclusive: " + (this.vehicle.SeasonPassExclusive ? "Yes" : "No");

            HasBeenPurchasedSwitch.Toggled += Switch_Toggled;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            VehicleItem vehicleItem = new VehicleItem
            {
                Id = vehicle.Id,
                HasBeenPurchased = e.Value
            };

            if (App.Database.SaveItem(vehicleItem))
            {
                DependencyService.Get<Toast>().Show("Data updated successfully");
                vehicle.HasBeenPurchased = e.Value;
            }
            else
            {
                DependencyService.Get<Toast>().Show("Unable to update data");
            }
        }
    }
}