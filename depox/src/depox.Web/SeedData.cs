using depox.Core.Entities;
using depox.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using depox.Core.Enums;

namespace depox.Web
{
    public static class SeedData
    {
        private static readonly Bin Bin1 = new  Bin()
        {
            Code = "B01",
            Description = "Try to get the sample to build."
        };

        private static readonly Bin Bin2 = new Bin()
        {
            Code = "B02",
            Description = "Review the different projects in the solution and how they relate to one another"
        };

        private static readonly Bin Bin3 = new Bin()
        {
            Code = "B03",
            Description = "Make sure all the tests run and review what they are doing."
        };

        private static readonly Item StockItem1 = new Item()
        {
            Code = "SI01",  
        };

        private static readonly Item StockItem2 = new Item()
        {
            Code = "SI02",
        };

        private static readonly Item StockItem3 = new Item()
        {
            Code = "SI03"
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {
                // Look for any TODO items.
                if (dbContext.ToDoItems.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);
                PopulateStockData(dbContext);

            }
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Bins)
            {
                dbContext.Remove(item);
            }
            foreach (var item in dbContext.Items)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();
            
            dbContext.Bins.Add(Bin1);
            dbContext.Bins.Add(Bin2);
            dbContext.Bins.Add(Bin3);

            dbContext.SaveChanges();

            dbContext.Entry<Bin>(Bin1).State = EntityState.Detached;
            dbContext.Entry<Bin>(Bin2).State = EntityState.Detached;
            dbContext.Entry<Bin>(Bin3).State = EntityState.Detached;
            dbContext.Items.Add(StockItem1);
            dbContext.Items.Add(StockItem2);
            dbContext.Entry<Bin>(Bin1).State = EntityState.Detached;
            dbContext.Items.Add(StockItem3);
            dbContext.SaveChanges();
        }

        public static void PopulateStockData(AppDbContext dbContext)
        {

            StockItem1.Bin = Bin1;
            StockItem1.StockQuantity = 10;
            dbContext.Items.Update(StockItem1);
            dbContext.SaveChanges();

            StockItem2.Bin = Bin1;
            StockItem2.StockQuantity = -5;
            dbContext.Items.Update(StockItem2);
            dbContext.SaveChanges();

            dbContext.Stocks.Add(new Stock()
                {BinId = StockItem1.Bin.Id, ItemId = StockItem1.Id, ActionType = StockActionType.IMPORT});

            dbContext.Stocks.Add(new Stock()
                { BinId = StockItem2.Bin.Id, ItemId = StockItem2.Id, ActionType = StockActionType.IMPORT });
            dbContext.SaveChanges();
        }
    }
}
