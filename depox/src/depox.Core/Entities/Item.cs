using Ardalis.GuardClauses;
using depox.Core.Events;
using depox.Core.Exceptions;
using depox.SharedKernel;

namespace depox.Core.Entities
{
    public class Item : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public decimal StockQuantity { get; set; }

        public int MinQuantity { get; set; } = 0;

        public int MaxQuantity { get; set; }

        public Bin Bin { get; set; }


        public bool IsOutOfStock(decimal removingQuantity)
        {
            if (StockQuantity < removingQuantity)
            {
                Events.Add(new ItemNegativeStockQuantity(this));
            }

            return StockQuantity < removingQuantity;
        }


        public void AddQuantity(decimal quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, decimal.MaxValue);

            StockQuantity += quantity;
        }

        public void SetQuantity(decimal quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, decimal.MaxValue);

            StockQuantity = quantity;
        }

    }
}