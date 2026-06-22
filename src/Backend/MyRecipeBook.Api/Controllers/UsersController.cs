using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost/*("register")*/]
        public IActionResult Register(
            [FromBody] RequestRegisterUserAccountJson request, 
            [FromServices] IRegisterUserAccountUseCase user)
        {
            user.Execute(request);

            return Ok();
        }
    }
}