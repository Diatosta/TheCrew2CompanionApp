using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static TheCrew2CompanionApp.Models.VehicleCategory;

namespace TheCrew2CompanionApp.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Brand VehicleBrand { get; set; }
        public float CostBucks { get; set; }
        public float CostCredits { get; set; }
        public bool HasBeenPurchased { get; set; }
        public ImageSource VehicleImage { get; set; }
        public int TopSpeedKMh { get; set; }
        public int LevelToUnlock { get; set; }
        public int PowerBHP { get; set; }
        public int Rating { get; set; }
        public VehicleCategories VehicleCategory { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public VehicleTypeOverall VehicleTypeOverall { get; set; }
    }
}
