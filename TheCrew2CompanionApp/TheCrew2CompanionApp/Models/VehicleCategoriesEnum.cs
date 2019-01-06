using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace TheCrew2CompanionApp.Models
{
    public static class VehicleCategoriesEnum
    {
        public enum VehicleCategories
        {
            [Description("No category")]
            None,
            [Description("Car")]
            Car,
            [Description("Boat")]
            Boat,
            [Description("Plane")]
            Plane,
            [Description("Helicopter")]
            Helicopter,
            [Description("Motorcycle")]
            Motorcycle
        }

        public enum VehicleTypes
        {
            [Description("No category")]
            None,
            [Description("Street Racing")]
            StreetRacing,
            [Description("Hypercar")]
            HyperCar,
            [Description("Drag")]
            Drag,
            [Description("Drift")]
            Drift,
            [Description("Touring Car")]
            TouringCar,
            [Description("Alpha Grand Prix")]
            AlphaGrandPrix,
            [Description("Powerboat")]
            PowerBoat,
            [Description("Air Racing")]
            AirRacing,
            [Description("Rally Raid")]
            RallyRaid,
            [Description("Motocross")]
            MotoCross,
            [Description("Rallycross")]
            RallyCross,
            [Description("Hovercraft")]
            HoverCraft,
            [Description("Aerobatic")]
            Aerobatic,
            [Description("Demolition Derby")]
            DemolitionDerby,
            [Description("Jetsprint")]
            JetSprint,
            [Description("Monster Truck")]
            MonsterTruck
        }

        public enum VehicleTypeOverall
        {
            [Description("No category")]
            None,
            [Description("Street Racing")]
            StreetRacing,
            [Description("Offroad")]
            Offroad,
            [Description("Freestyle")]
            Freestyle,
            [Description("Touring Car")]
            TouringCar
        }

        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }

            return null;
        }
    }
}
