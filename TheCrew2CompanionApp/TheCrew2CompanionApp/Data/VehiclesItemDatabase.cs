using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheCrew2CompanionApp.Models;

namespace TheCrew2CompanionApp.Data
{
    public class VehiclesItemDatabase
    {
        readonly SQLiteConnection database;

        public VehiclesItemDatabase(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<VehicleItem>();
        }

        public List<VehicleItem> GetItems()
        {
            return database.Table<VehicleItem>().ToList();
        }

        public List<VehicleItem> GetItemsPurchased()
        {
            return database.Query<VehicleItem>("SELECT * FROM [VehicleItem] WHERE [HasBeenPurchased] = 1");
        }

        public VehicleItem GetItem(int id)
        {
            return database.Get<VehicleItem>(id);
        }

        public bool SaveItem(VehicleItem item)
        {
            var rowsAffected = database.Update(item);
            if(rowsAffected == 0)
            {
                // The item does not exist in the database so lets insert it
                rowsAffected = database.Insert(item);
            }

            var success = rowsAffected > 0;
            return success;
        }

        public int DeleteItem(VehicleItem item)
        {
            return database.Delete(item);
        }
    }
}
