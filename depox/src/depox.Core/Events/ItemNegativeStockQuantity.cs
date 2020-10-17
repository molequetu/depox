using depox.Core.Entities;
using depox.SharedKernel;

namespace depox.Core.Events
{
    public class ItemNegativeStockQuantity : BaseDomainEvent
    {
        public Item NegativeStock { get; set; }

        public ItemNegativeStockQuantity(Item negativeStock)
        {
            NegativeStock = negativeStock;
        }
    }
}