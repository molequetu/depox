﻿using System;
using System.Collections.Generic;
using depox.Core.Entities;
using depox.Core.Enums;

namespace depox.Web.ApiModels
{
    public class StockDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public decimal Quantity { get; set; }

        public StockActionType ActionType { get; set; }

        public DateTime CreatedAt { get; set; }

        public Bin Bin { get; set; }

        public Item Item { get; set; }


        public static StockDto FromStock(Stock stockMovement)
        {
            return new StockDto()
            {
                Id = stockMovement.Id,
                UserId = stockMovement.UserId,
                Quantity = stockMovement.Quantity,
                ActionType = stockMovement.ActionType,
                CreatedAt = stockMovement.CreatedAt,
                Bin = stockMovement.Bin,
                Item = stockMovement.Item
            };
        }
        public static List<StockDto> FromStocks(List<Stock> stockMovements)
        {
            List<StockDto> stocks = new List<StockDto>();
            foreach (var stockMovement in stockMovements)
            {
                stocks.Add(new StockDto()
                {
                    Id = stockMovement.Id,
                    UserId = stockMovement.UserId,
                    Quantity = stockMovement.Quantity,
                    ActionType = stockMovement.ActionType,
                    CreatedAt = stockMovement.CreatedAt,
                    Bin = stockMovement.Bin,
                    Item = stockMovement.Item
                });
            }
            return stocks;
        }
    }


    public class StockImportExportDto
    {
        public string BinCode { get; set; }

        public  string ItemCode { get; set; }

        public decimal Quantity { get; set; }
    }
}