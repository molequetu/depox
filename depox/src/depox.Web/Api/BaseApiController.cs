using Microsoft.AspNetCore.Mvc;

namespace depox.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
