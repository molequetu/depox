using System;
using depox.Core.Enums;
using depox.SharedKernel;

namespace depox.Core.Entities
{
    public class Stock : BaseEntity
    {
        public int BinId { get; set; }

        public int ItemId { get; set; }

        public string UserId { get; set; }

        public decimal Quantity { get; set; }

        public StockActionType ActionType { get; set; }

        public DateTime CreatedAt { get; set; }

        public Bin Bin { get; set; }

        public  Item Item { get; set; }
    }
}