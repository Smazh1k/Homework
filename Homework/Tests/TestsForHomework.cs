using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Homework.Tests
{
    public class CrudTests
    {
        [Fact]
        public void CanAddItem()
        {
            using (var context = new DbContext())
            {
                var crud = new CrudOperations(context);
                crud.AddItem(new Item { Name = "Car", Type = "A" });
                var addedItem = context.Items.Single();
                Assert.Equal("Car", addedItem.Name);
            }
        }

        [Fact]
        public void CanGetItemById()
        {
            using (var context = new DbContext())
            {
                var crud = new CrudOperations(context);
                crud.AddItem(new Item { Name = "Car", Type = "A" });
                var addedItem = context.Items.Single();
                var getItem = crud.GetItemById(addedItem.Id);
                Assert.Equal("Car", getItem.Name);
            }
        }

        [Fact]
        public void CanRemoveItemById()
        {
            using (var context = new DbContext())
            {
                var crud = new CrudOperations(context);
                crud.AddItem(new Item { Name = "Car", Type = "A" });
                var addedItem = context.Items.Single();
                crud.RemoveItemById(addedItem.Id);
                Assert.Empty(context.Items);
            }
        }

        [Fact]
        public void CanRemoveItemByType()
        {
            using (var context = new DbContext())
            {
                var crud = new CrudOperations(context);
                crud.AddItem(new Item { Name = "Car", Type = "A" });
                crud.AddItem(new Item { Name = "Song", Type = "B" });
                crud.RemoveItemByType("A");
                Assert.Single(context.Items); // Only "Song" should remain
            }
        }
    }
}
