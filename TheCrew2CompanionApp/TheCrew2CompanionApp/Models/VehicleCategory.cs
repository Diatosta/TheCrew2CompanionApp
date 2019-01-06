using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static TheCrew2CompanionApp.Models.VehicleCategoriesEnum;

namespace TheCrew2CompanionApp.Models
{
    public class VehicleCategory
    {
        public VehicleTypes VehicleActualTypes { get; set; }
        public string Name { get; set; }
        public int MaximumRating { get; set; }
        public ImageSource CategoryImage { get; set; }
    }
}
