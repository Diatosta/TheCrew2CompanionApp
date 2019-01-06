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
using Newtonsoft.Json;

namespace TheCrew2CompanionApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();

            LoadedData.CreateCategories();

            LoadedData.LoadBrands();

            LoadedData.LoadVehicles();

            carsList.FlowItemsSource = LoadedData.Vehicles;
        }

        
        async void CarsList_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            Vehicle vehicle = (Vehicle)e.Item;

            await Navigation.PushAsync(new VehicleDetailsPage(vehicle));
        }
    }
}