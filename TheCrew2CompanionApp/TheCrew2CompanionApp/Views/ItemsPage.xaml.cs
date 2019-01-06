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

namespace TheCrew2CompanionApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();

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
                HasBeenPurchased = false,
                VehicleImage = ImageSource.FromResource("TheCrew2CompanionApp.CarImages.TC2Abarth124rally.jpg")
            });

            LoadedData.Vehicles.Add(new Vehicle
            {
                Name = "124 spider",
                VehicleBrand = LoadedData.Brands["Abarth"],
                CostBucks = 105700f,
                CostCredits = 15100,
                HasBeenPurchased = false,
                VehicleImage = ImageSource.FromResource("TheCrew2CompanionApp.CarImages.TC2Abarth124spider.jpg")
            });

            carsList.FlowItemsSource = LoadedData.Vehicles;
        }

        
        private void CarsList_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            Vehicle vehicle = (Vehicle)e.Item;
            DisplayAlert("_OnFlowItemTapped", vehicle.VehicleBrand.Name + " " + vehicle.Name, "ok");
        }
    }
}