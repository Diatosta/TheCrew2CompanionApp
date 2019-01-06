using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using static TheCrew2CompanionApp.Models.VehicleCategoriesEnum;
using static TheCrew2CompanionApp.Models.VehicleCategory;

namespace TheCrew2CompanionApp.Models
{
    public class Vehicle : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Brand VehicleBrand { get; set; }
        public int CostBucks { get; set; }
        public int CostCredits { get; set; }

        private bool hasBeenPurchased;
        public bool HasBeenPurchased
        {
            get { return hasBeenPurchased; }
            set
            {
                hasBeenPurchased = value;
                OnPropertyChanged("HasBeenPurchased");
            }
        }

        public ImageSource VehicleImage { get; set; }
        public int TopSpeedKMh { get; set; }
        public int LevelToUnlock { get; set; }
        public bool SeasonPassExclusive { get; set; }
        public int PowerBHP { get; set; }
        public int Rating { get; set; }
        public VehicleCategories VehicleActualCategory { get; set; }
        public VehicleTypeOverall VehicleActualTypeOverall { get; set; }
        public VehicleCategory VehicleCategory { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
