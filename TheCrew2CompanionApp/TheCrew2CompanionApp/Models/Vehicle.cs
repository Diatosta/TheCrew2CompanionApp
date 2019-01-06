using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TheCrew2CompanionApp.Models
{
    public class Vehicle
    {
        public string Name { get; set; }
        public Brand VehicleBrand { get; set; }
        public float CostBucks { get; set; }
        public float CostCredits { get; set; }
        public bool HasBeenPurchased { get; set; }
        public ImageSource VehicleImage { get; set; }
    }
}
