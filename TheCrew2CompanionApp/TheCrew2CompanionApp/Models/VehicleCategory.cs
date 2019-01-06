using System;
using System.Collections.Generic;
using System.Text;

namespace TheCrew2CompanionApp.Models
{
    public class VehicleCategory
    {
        public enum VehicleCategories
        {
            None,
            Car,
            Boat,
            Plane,
            Helicopter,
            Bike
        }

        public enum VehicleTypes
        {
            None,
            StreetRacing,
            HyperCar,
            Drag,
            Drift,
            TouringCar,
            AlphaGrandPrix,
            PowerBoat,
            AirRacing,
            RallyRaid,
            MotoCross,
            RallyCross,
            HoverCraft,
            Aerobatic,
            DemolitionDerby,
            JetSprint,
            MonsterTruck
        }

        public enum VehicleTypeOverall
        {
            None,
            StreetRacing,
            Offroad,
            Freestyle,
            TouringCar
        }
    }
}
