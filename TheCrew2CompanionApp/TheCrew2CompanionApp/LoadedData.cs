using System;
using System.Collections.Generic;
using System.Text;
using TheCrew2CompanionApp.Models;
using static TheCrew2CompanionApp.Models.VehicleCategory;

namespace TheCrew2CompanionApp
{
    public class LoadedData
    {
        public static List<Vehicle> Vehicles = new List<Vehicle>();
        public static Dictionary<string, Brand> Brands = new Dictionary<string, Brand>();
        public static Dictionary<VehicleTypes, VehicleGlobalCategories> VehicleCategories = new Dictionary<VehicleTypes, VehicleGlobalCategories>();
    }
}
