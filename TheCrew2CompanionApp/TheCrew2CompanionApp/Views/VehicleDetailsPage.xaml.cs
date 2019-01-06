using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            UnlockLevelLabel.Text = "Unlock level: " + (this.vehicle.LevelToUnlock > 0 ? this.vehicle.LevelToUnlock.ToString() : "Not unlockable through leveling up");

            TopSpeedKmhLabel.Text = "Top speed (Kmh): " + (this.vehicle.TopSpeedKMh > 0 ? this.vehicle.TopSpeedKMh.ToString() : "Not available");

            TopSpeedMphLabel.Text = "Top speed (Mph): " + (this.vehicle.TopSpeedKMh > 0 ? (this.vehicle.TopSpeedKMh / 1.609f).ToString() : "Not available");

            PowerBHPLabel.Text = "Bhp: " + (this.vehicle.PowerBHP > 0 ? this.vehicle.PowerBHP.ToString() : "Not available");
            
             VehicleGlobalCategories currentVehicleCategory = LoadedData.VehicleCategories[vehicle.VehicleType];

            RatingLabel.Text = "Rating: " + this.vehicle.Rating.ToString() + "/" + currentVehicleCategory.MaximumRating.ToString();

            CategoryLabel.Text = "Category: " + currentVehicleCategory.Name;

        }
	}
}