using depox.Core.Entities;
using depox.SharedKernel.Interfaces;
using depox.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using depox.Core.Exceptions;
using depox.Core.Interfaces;
using depox.Core.Services;
using depox.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace depox.Web.Api
{
    public class StocksController : BaseApiController
    {
        private readonly IRepository<Stock> _repository;

        private readonly IStockService _stockService;

        public readonly AppDbContext _dbContext;
        public StocksController(IRepository<Stock> repository, AppDbContext dbContext, IStockService stockService)
        {
            _repository = repository;
            _dbContext = dbContext;
            _stockService = stockService;
        }

        // GET: api/Stocks
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var stocks = _dbContext.Stocks.Include(x => x.Bin).Include(x => x.Item).ToList();
            return Ok(StockDto.FromStocks(stocks.OrderByDescending(stock => stock.CreatedAt).ToList()));
        }

        [HttpPost("/import")]
        [Produces("application/json")]
        public async Task<IActionResult> Import([FromBody] StockImportExportDto stockImport)
        {
            var bin = _dbContext.Bins.SingleOrDefault(b => b.Code == stockImport.BinCode);
            var item = _dbContext.Items.SingleOrDefault(b => b.Code == stockImport.ItemCode);

            if (bin == null) return NotFound(new { status = HttpStatusCode.NotFound, message = "Bin does not exist, try another bin or add it" });
            if (item == null) return NotFound(new { status = HttpStatusCode.NotFound, message = "Item does not exist, try another item or add it" });
           
            await _stockService.ImportStock(bin.Id, item.Id , stockImport.Quantity);
            return Ok(new { status = HttpStatusCode.Created, message = "Stock successful imported" });
        }

        [HttpPost("/export")]
        [Produces("application/json")]
        public async Task<IActionResult> Export([FromBody] StockImportExportDto stockImport)
        {

            var bin = _dbContext.Bins.SingleOrDefault(b => b.Code == stockImport.BinCode);
            var item = _dbContext.Items.SingleOrDefault(b => b.Code == stockImport.ItemCode);

            if (bin == null) return NotFound(new { status = HttpStatusCode.NotFound, message = "Bin does not exist, try another bin or add it" });
            if (item == null) return NotFound(new { status = HttpStatusCode.NotFound, message = "Item does not exist, try another item or add it" });
            try
            {
                await _stockService.ExportStock(bin.Id, item.Id, stockImport.Quantity);
            }
            catch (OutOfStockException ex)
            {
                return Conflict(new { status = HttpStatusCode.Conflict, message = ex.Message});
            }

            return Ok(new { status = HttpStatusCode.Created, message = "Stock successful imported" });
        }
    }
}
