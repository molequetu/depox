using Ardalis.ApiEndpoints;
using depox.Core.Entities;
using depox.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace depox.Web.Endpoints.ToDoItems
{
    public class Delete : BaseAsyncEndpoint<int, ToDoItemResponse>
    {
        private readonly IRepository<ToDoItem> _repository;

        public Delete(IRepository<ToDoItem> repository)
        {
            _repository = repository;
        }

        [HttpDelete("/ToDoItems/{id:int}")]
        [SwaggerOperation(
            Summary = "Deletes a ToDoItem",
            Description = "Deletes a ToDoItem",
            OperationId = "ToDoItem.Delete",
            Tags = new[] { "ToDoItemEndpoints" })
        ]
        public override async Task<ActionResult<ToDoItemResponse>> HandleAsync(int id)
        {
            var itemToDelete = await _repository.GetByIdAsync(id);
            if (itemToDelete == null) return NotFound();

            await _repository.DeleteAsync(itemToDelete);

            return NoContent();
        }
    }
}
