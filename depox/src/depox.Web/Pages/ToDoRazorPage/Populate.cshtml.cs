using depox.Core;
using depox.Core.Entities;
using depox.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace depox.Web.Pages.ToDoRazorPage
{
    public class PopulateModel : PageModel
    {
        private readonly IRepository<ToDoItem> _repository;

        public PopulateModel(IRepository<ToDoItem> repository)
        {
            _repository = repository;
        }

        public int RecordsAdded { get; set; }

        public void OnGet()
        {
            RecordsAdded = DatabasePopulator.PopulateDatabase(_repository);
        }
    }
}
