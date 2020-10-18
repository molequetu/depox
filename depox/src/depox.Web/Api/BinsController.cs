using System.Collections.Generic;
using depox.Core.Entities;
using depox.SharedKernel.Interfaces;
using depox.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using depox.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace depox.Web.Api
{
    public class BinsController : BaseApiController
    {
        private readonly IRepository<Bin> _repository;

        //public readonly AppDbContext _dbContext;
        public BinsController(IRepository<Bin> repository)
        {
            _repository = repository;
        }

        // GET: api/Bins
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var bins = (await _repository.ListAsync())
                            .Select(BinDto.FromBin);
            return Ok(bins);
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = BinDto.FromBin(await _repository.GetByIdAsync(id));
            return Ok(item);
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BinDto bin)
        {
            var newBin = new Bin()
            {
                Code = bin.Code,
                Name = bin.Name,
                Description = bin.Description,
            };
            await _repository.AddAsync(newBin);
            return Ok(BinDto.FromBin(newBin));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BinDto bin)
        {
            var updatedBin = new Bin()
            {
                Id = bin.Id,
                Code = bin.Code,
                Name = bin.Name,
                Description = bin.Description
            };
            await _repository.UpdateAsync(updatedBin);

            return Ok(BinDto.FromBin(updatedBin));
        }

        //[HttpGet("{id:int}/items")]
        //public async Task<IActionResult> GetBinItems(int id)
        //{
        //    var bins = _dbContext.Bins.Where(bin => bin.Id == id).Include(b => b.Items).Select(b => b.Items).ToList();

        //    return Ok(bins);
        //}

    }
}
