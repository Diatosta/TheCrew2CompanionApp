using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TheCrew2CompanionApp.Models;
using TheCrew2CompanionApp.Views;
using TheCrew2CompanionApp.ViewModels;
using DLToolkit.Forms.Controls;
using System.Reflection;
using static TheCrew2CompanionApp.Models.VehicleCategory;

namespace TheCrew2CompanionApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();

            LoadedData.VehicleCategories.Add(VehicleTypes.RallyCross, new VehicleGlobalCategories
            {
                Name = "RallyCross",
                VehicleTypes = VehicleTypes.RallyCross,
                MaximumRating = 230
            });

            LoadedData.VehicleCategories.Add(VehicleTypes.None, new VehicleGlobalCategories
            {
                Name = "No category",
                VehicleTypes = VehicleTypes.None,
                MaximumRating = 0
            });

            LoadedData.Brands.Add("Abarth", new Brand
            {
                Name = "Abarth",
                BrandImage = ImageSource.FromResource("TheCrew2CompanionApp.CarImages.ManufacturerAbarth.png")
            });

            LoadedData.Vehicles.Add(new Vehicle
            {
                Name = "124 rally",
                VehicleBrand = LoadedData.Brands["Abarth"],
                CostBucks = 314000f,
                CostCredits = 44900,
                LevelToUnlock = -1,
                HasBeenPurchased = false,
                VehicleImage = ImageSource.FromResource("TheCrew2CompanionApp.CarImages.TC2Abarth124rally.jpg"),

                TopSpeedKMh = -1,
                PowerBHP = 300,
                Rating = 131,

                VehicleCategory = VehicleCategories.Car,
                VehicleType = VehicleTypes.RallyCross,
                VehicleTypeOverall = VehicleTypeOverall.Offroad
            });

            LoadedData.Vehicles.Add(new Vehicle
            {
                Name = "124 spider",
                VehicleBrand = LoadedData.Brands["Abarth"],
                CostBucks = 105700f,
                CostCredits = 15100,
                HasBeenPurchased = false,
                VehicleImage = ImageSource.FromResource("TheCrew2CompanionApp.CarImages.TC2Abarth124spider.jpg"),
                
                TopSpeedKMh = 232,
                PowerBHP = 170,
                Rating = 53
            });

            carsList.FlowItemsSource = LoadedData.Vehicles;
        }

        
        async void CarsList_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            Vehicle vehicle = (Vehicle)e.Item;

            await Navigation.PushAsync(new VehicleDetailsPage(vehicle));
        }
    }
}