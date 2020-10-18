using depox.Core.Entities;
using depox.SharedKernel.Interfaces;
using depox.Web.ApiModels;
using depox.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace depox.Web.Api
{
    public class ToDoItemsController : BaseApiController
    {
        private readonly IRepository<ToDoItem> _repository;

        public ToDoItemsController(IRepository<ToDoItem> repository)
        {
            _repository = repository;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var items = (await _repository.ListAsync())
                            .Select(ToDoItemDTO.FromToDoItem);
            return Ok(items);
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = ToDoItemDTO.FromToDoItem(await _repository.GetByIdAsync(id));
            return Ok(item);
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoItemDTO item)
        {
            var todoItem = new ToDoItem()
            {
                Title = item.Title,
                Description = item.Description
            };
            await _repository.AddAsync(todoItem);
            return Ok(ToDoItemDTO.FromToDoItem(todoItem));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ToDoItemDTO item)
        {
            var todoItem = new ToDoItem()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description
            };
            await _repository.UpdateAsync(todoItem);

            return Ok(ToDoItemDTO.FromToDoItem(todoItem));
        }

        [HttpPatch("{id:int}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var toDoItem = await _repository.GetByIdAsync(id);
            toDoItem.MarkComplete();
            await _repository.UpdateAsync(toDoItem);

            return Ok(ToDoItemDTO.FromToDoItem(toDoItem));
        }
    }
}
