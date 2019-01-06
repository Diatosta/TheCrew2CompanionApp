using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheCrew2CompanionApp.Models
{
    public class VehicleItem
    {
        [PrimaryKey]
        public int Id { get; set; }
        public bool HasBeenPurchased { get; set; }
    }
}
