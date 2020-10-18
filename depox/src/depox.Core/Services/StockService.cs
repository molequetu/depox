using System;
using System.Threading.Tasks;
using depox.Core.Entities;
using depox.Core.Enums;
using depox.Core.Exceptions;
using depox.Core.Interfaces;
using depox.SharedKernel.Interfaces;

namespace depox.Core.Services
{
    public class StockService : IStockService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<Bin> _binRepository;
        private readonly IRepository<Stock> _stockRepository;

        public StockService(IRepository<Item> itemRepository, IRepository<Bin> binRepository,
            IRepository<Stock> stockRepository)
        {
            _itemRepository = itemRepository;
            _binRepository = binRepository;
            _stockRepository = stockRepository;
        }

        public async Task ImportStock(int binId, int itemId, decimal quantity)
        {
            var item = await _itemRepository.GetByIdAsync(itemId);
            if (item == null) throw new ItemNotFoundException(itemId);
            var bin = await _binRepository.GetByIdAsync(binId);
            if (bin == null) throw new BinNotFoundException(binId);

            item.AddQuantity(quantity);

            // update items stock quantity
            await _itemRepository.UpdateAsync(item);

            // add a new import stock movement
            Stock importedStock = new Stock()
            {
                BinId = binId,
                ItemId = itemId,
                ActionType = StockActionType.IMPORT,
                CreatedAt = DateTime.Now,
                Quantity = quantity,
                UserId = "admin"
            };
            await _stockRepository.AddAsync(importedStock);
        }

        public async Task ExportStock(int binId, int itemId, decimal quantity)
        {
            var item = await _itemRepository.GetByIdAsync(itemId);
            if (item == null) throw new ItemNotFoundException(itemId);

            // does this item belongs to the given bin or does the item have a bin assigned in order to export;
            //if (item.Bin == null || item.Bin.Id != binId) throw new;
            var bin = await _binRepository.GetByIdAsync(binId);
            if (bin == null) throw new BinNotFoundException(binId);

            // quantity applied to remove is greater than the available item's quantity, cant export
            if (quantity > item.StockQuantity)
            {
                throw new OutOfStockException(itemId);
            }

            item.SetQuantity(item.StockQuantity - quantity);
            await _itemRepository.UpdateAsync(item);
            Stock exportedStock = new Stock()
            {
                BinId = binId,
                ItemId = itemId,
                ActionType = StockActionType.EXPORT,
                CreatedAt = DateTime.Now,
                Quantity = quantity,
                UserId = "admin"
            };
            await _stockRepository.AddAsync(exportedStock);

        }

        public Task TransferStock(int fromBin, int toBin, int itemId, decimal quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}
