using System;
using xUnit;

public class Class1
{
    public class CrudTests
    {
        [Fact]
        public void CanAddAndRetrieveItem()
        {
            using (var dbContext = new AppDbContext())
            {
                var crudService = new CrudService(dbContext);

                crudService.PerformActionOnAdd(name => crudService.AddItem(name));
                var item = crudService.GetItemById(1);

                Assert.NotNull(item);
                Assert.Equal("TestItem", item.Name);
            }
        }

        [Fact]
        public void CanDeleteItemById()
        {
            using (var dbContext = new AppDbContext())
            {
                var crudService = new CrudService(dbContext);

                crudService.PerformActionOnAdd(name => crudService.AddItem(name));
                crudService.DeleteItemById(1);

                var item = crudService.GetItemById(1);

                Assert.Null(item);
            }
        }

        [Fact]
        public void CanDeleteItemByObjects()
        {
            using (var dbContext = new AppDbContext())
            {
                var crudService = new CrudService(dbContext);

                crudService.PerformActionOnAdd(name => crudService.AddItem(name));
                crudService.PerformActionOnAdd(name => crudService.AddItem(name));

                var item1 = crudService.GetItemById(1);
                var item2 = crudService.GetItemById(2);

                crudService.DeleteItemByObjects(item1, item2);

                Assert.Null(crudService.GetItemById(1));
                Assert.Null(crudService.GetItemById(2));
            }
        }
    }

}
