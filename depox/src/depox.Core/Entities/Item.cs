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


        private bool OutOfStock()
        {
            if (StockQuantity <= 0)
            {
                Events.Add(new ItemNegativeStockQuantity(this));
            }
            return StockQuantity < 0;
        }

        public void RemoveStock(decimal currentQuantity, decimal quantityToRemove)
        {
            var finalQuantity = currentQuantity - quantityToRemove;
            StockQuantity = finalQuantity;
            if (OutOfStock())
            {
                throw new  OutOfStockException(Id);
            }
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