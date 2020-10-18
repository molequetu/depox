using depox.Core;
using depox.Core.Entities;
using depox.SharedKernel.Interfaces;
using depox.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace depox.Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IRepository<ToDoItem> _repository;

        public ToDoController(IRepository<ToDoItem> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var items = (await _repository.ListAsync())
                            .Select(ToDoItemDTO.FromToDoItem);
            return View(items);
        }

        public IActionResult Populate()
        {
            int recordsAdded = DatabasePopulator.PopulateDatabase(_repository);
            return Ok(recordsAdded);
        }
    }
}
