
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TheCrew2CompanionApp.Models;

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

            LoadedData.LoadUserVehicleData();

            carsList.FlowItemsSource = LoadedData.Vehicles;

            // Set the HasBeenPurchased variable for every vehicle.
            foreach(VehicleItem vehicleItem in LoadedData.VehicleItems)
            {
                Vehicle vehicle = LoadedData.Vehicles.Find(vehicleToGet => vehicleToGet.Id == vehicleItem.Id);

                vehicle.HasBeenPurchased = vehicleItem.HasBeenPurchased;
            }
        }

        
        async void CarsList_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            Vehicle vehicle = (Vehicle)e.Item;

            await Navigation.PushAsync(new VehicleDetailsPage(vehicle));
        }
    }
}