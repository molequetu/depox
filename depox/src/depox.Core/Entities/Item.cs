using depox.Core.Events;
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


        public bool StockIsNegative()
        {
            if (StockQuantity < 0)
            {
                Events.Add(new ItemNegativeStockQuantity(this));
            }
            return StockQuantity < 0;
        }

    }
}