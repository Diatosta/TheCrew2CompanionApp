using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TheCrew2CompanionApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using static TheCrew2CompanionApp.Models.VehicleCategory;

namespace TheCrew2CompanionApp
{
    public class LoadedData
    {
        public static List<Vehicle> Vehicles = new List<Vehicle>();
        public static Dictionary<string, Brand> Brands = new Dictionary<string, Brand>();
        public static Dictionary<VehicleTypes, VehicleGlobalCategories> VehicleCategories = new Dictionary<VehicleTypes, VehicleGlobalCategories>();

        public static void CreateCategories()
        {
            VehicleCategories.Add(VehicleTypes.None, new VehicleGlobalCategories
            {
                Name = "No category",
                VehicleTypes = VehicleTypes.None,
                MaximumRating = 0
            });

            VehicleCategories.Add(VehicleTypes.StreetRacing, new VehicleGlobalCategories
            {
                Name = "Street Racing",
                VehicleTypes = VehicleTypes.StreetRacing,
                MaximumRating = 280
            });

            VehicleCategories.Add(VehicleTypes.HyperCar, new VehicleGlobalCategories
            {
                Name = "Hypercar",
                VehicleTypes = VehicleTypes.HyperCar,
                MaximumRating = 320
            });

            VehicleCategories.Add(VehicleTypes.RallyCross, new VehicleGlobalCategories
            {
                Name = "RallyCross",
                VehicleTypes = VehicleTypes.RallyCross,
                MaximumRating = 230
            });
        }

        public static void LoadBrands()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadedData)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("TheCrew2CompanionApp.BrandsList.json");

            string json;

            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            dynamic dynamicObject = JsonConvert.DeserializeObject<dynamic>(json);

            foreach(dynamic brandToAdd in dynamicObject)
            {
                foreach(dynamic brandObject in brandToAdd)
                {
                    string imageSource = brandObject["Image"];

                    Brand brand = new Brand
                    {
                        Name = brandObject["Name"],
                        BrandImage = ImageSource.FromResource("TheCrew2CompanionApp.BrandImages." + imageSource)
                    };

                    Brands.Add(brand.Name, brand);
                }
            }
        }

        public static void LoadVehicles()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadedData)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("TheCrew2CompanionApp.CarsList.json");

            string json;

            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            dynamic dynamicObject = JsonConvert.DeserializeObject<dynamic>(json);

            foreach (dynamic vehicleToAdd in dynamicObject)
            {
                foreach(dynamic vehicleObject in vehicleToAdd)
                {
                    string brand = vehicleObject["Brand"];
                    string imageSource = vehicleObject["Image"];

                    Vehicle vehicle = new Vehicle
                    {
                        Id = vehicleObject["Id"],
                        Name = vehicleObject["Name"],
                        VehicleBrand = Brands[brand],
                        CostBucks = vehicleObject["CostBucks"],
                        CostCredits = vehicleObject["CostCredits"],
                        VehicleImage = ImageSource.FromResource("TheCrew2CompanionApp.CarImages." + imageSource),
                        TopSpeedKMh = vehicleObject["TopSpeedKMh"],
                        LevelToUnlock = vehicleObject["LevelToUnlock"],
                        PowerBHP = vehicleObject["PowerBHP"],
                        Rating = vehicleObject["Rating"],
                        VehicleCategory = (VehicleCategories)vehicleObject["Category"],
                        VehicleType = (VehicleTypes)vehicleObject["Type"],
                        VehicleTypeOverall = (VehicleTypeOverall)vehicleObject["TypeOverall"]
                    };

                    Vehicles.Add(vehicle);
                }
            }
        }
    }
}
