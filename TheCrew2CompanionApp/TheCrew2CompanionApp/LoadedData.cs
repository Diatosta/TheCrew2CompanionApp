using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TheCrew2CompanionApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using static TheCrew2CompanionApp.Models.VehicleCategoriesEnum;
using static TheCrew2CompanionApp.Models.VehicleCategory;

namespace TheCrew2CompanionApp
{
    public class LoadedData
    {
        public static List<Vehicle> Vehicles = new List<Vehicle>();
        public static List<VehicleItem> VehicleItems = new List<VehicleItem>();
        public static Dictionary<string, Brand> Brands = new Dictionary<string, Brand>();
        public static Dictionary<VehicleTypes, VehicleCategory> VehicleCategories = new Dictionary<VehicleTypes, VehicleCategory>();

        public static void CreateCategories()
        {
            VehicleCategories.Add(VehicleTypes.None, new VehicleCategory
            {
                Name = "No category",
                VehicleActualTypes = VehicleTypes.None,
                MaximumRating = 0,
                CategoryImage = null
            });

            VehicleCategories.Add(VehicleTypes.StreetRacing, new VehicleCategory
            {
                Name = "Street Racing",
                VehicleActualTypes = VehicleTypes.StreetRacing,
                MaximumRating = 280,
                CategoryImage = ImageSource.FromResource("TheCrew2CompanionApp.CategoryImages.TC2LogoSR.jpg")
            });

            VehicleCategories.Add(VehicleTypes.HyperCar, new VehicleCategory
            {
                Name = "Hypercar",
                VehicleActualTypes = VehicleTypes.HyperCar,
                MaximumRating = 320,
                CategoryImage = ImageSource.FromResource("TheCrew2CompanionApp.CategoryImages.TC2LogoHC.jpg")
            });

            VehicleCategories.Add(VehicleTypes.Drift, new VehicleCategory
            {
                Name = "Drift",
                VehicleActualTypes = VehicleTypes.Drift,
                MaximumRating = 240,
                CategoryImage = ImageSource.FromResource("TheCrew2CompanionApp.CategoryImages.TC2LogoDF.jpg")
            });

            VehicleCategories.Add(VehicleTypes.RallyCross, new VehicleCategory
            {
                Name = "RallyCross",
                VehicleActualTypes = VehicleTypes.RallyCross,
                MaximumRating = 230,
                CategoryImage = ImageSource.FromResource("TheCrew2CompanionApp.CategoryImages.TC2LogoRX.jpg")
            });

            VehicleCategories.Add(VehicleTypes.MonsterTruck, new VehicleCategory
            {
                Name = "Monster Truck",
                VehicleActualTypes = VehicleTypes.MonsterTruck,
                MaximumRating = 140,
                CategoryImage = ImageSource.FromResource("TheCrew2CompanionApp.CategoryImages.TC2LogoRX.jpg")
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
                    VehicleTypes vehicleTypes = vehicleObject["Type"];

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
                        SeasonPassExclusive = vehicleObject["SeasonPassExclusive"],
                        PowerBHP = vehicleObject["PowerBHP"],
                        Rating = vehicleObject["Rating"],
                        VehicleActualCategory = (VehicleCategories)vehicleObject["Category"],
                        VehicleCategory = LoadedData.VehicleCategories[vehicleTypes],
                        VehicleActualTypeOverall = (VehicleTypeOverall)vehicleObject["TypeOverall"]
                    };

                    Vehicles.Add(vehicle);
                }
            }
        }

        public static void LoadUserVehicleData()
        {
            VehicleItems = App.Database.GetItems(); 
        }
    }
}
