using depox.Core.Entities;
using depox.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace depox.Web.Pages.ToDoRazorPage
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<ToDoItem> _repository;

        public List<ToDoItem> ToDoItems { get; set; }

        public IndexModel(IRepository<ToDoItem> repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            ToDoItems = await _repository.ListAsync();
        }
    }
}
