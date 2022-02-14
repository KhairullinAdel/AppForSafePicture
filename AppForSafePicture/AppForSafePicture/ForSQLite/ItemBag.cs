using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppForSafePicture
{
    public class ItemBag
    {
        SQLiteConnection db;
        public ItemBag(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<CustomItem>();
        }

        public IEnumerable<CustomItem> GetAll()
        {
            return db.Table<CustomItem>().ToList();
        }

        public CustomItem GetCertain(int id)
        {
            return db.Get<CustomItem>(id);
        }

        public int DeleteCertain(int id)
        {
            return db.Delete<CustomItem>(id);
        }

        public int SaveNew(CustomItem c)
        {
            if (c.Id != 0)
            {
                db.Update(c);
                return c.Id;
            }
            else
            {
                return db.Insert(c);
            }
        }
    }
}
