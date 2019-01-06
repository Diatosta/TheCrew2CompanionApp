using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCrew2CompanionApp.Interfaces;
using TheCrew2CompanionApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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

            UnlockLevelLabel.Text = "Unlock level: " + (this.vehicle.LevelToUnlock > 0 ? this.vehicle.LevelToUnlock.ToString() : "N/A");

            TopSpeedKmhLabel.Text = "Top speed (Kmh): " + (this.vehicle.TopSpeedKMh > 0 ? this.vehicle.TopSpeedKMh.ToString() : "N/A");

            TopSpeedMphLabel.Text = "Top speed (Mph): " + (this.vehicle.TopSpeedKMh > 0 ? (this.vehicle.TopSpeedKMh / 1.609f).ToString() : "N/A");

            PowerBHPLabel.Text = "Bhp: " + (this.vehicle.PowerBHP > 0 ? this.vehicle.PowerBHP.ToString() : "N/A");
            
             VehicleGlobalCategories currentVehicleCategory = LoadedData.VehicleCategories[vehicle.VehicleType];

            RatingLabel.Text = "Rating: " + this.vehicle.Rating.ToString() + "/" + currentVehicleCategory.MaximumRating.ToString();

            CategoryLabel.Text = "Category: " + currentVehicleCategory.Name;

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