using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace Homework
{
    public class CrudOperations
    {
        private readonly DbContext dbContext;

        public CrudOperations(DbContext context)
        {
            dbContext = context;
            dbContext.Database.EnsureCreated(); // Utwórz bazę danych, jeśli nie istnieje
        }

        public void AddItem(Item item)
        {
            dbContext.Items.Add(item);
            dbContext.SaveChanges();
        }

        public Item GetItemById(int id)
        {
            return dbContext.Items.Find(id);
        }

        public void RemoveItemById(int id)
        {
            var item = dbContext.Items.Find(id);
            if (item != null)
            {
                dbContext.Items.Remove(item);
                dbContext.SaveChanges();
            }
        }

        public void RemoveItemByType(string type)
        {
            var itemsToRemove = dbContext.Items.Where(x => x.Type == type).ToList();
            foreach (var item in itemsToRemove)
            {
                dbContext.Items.Remove(item);
            }
            dbContext.SaveChanges();
        }
    }
}
