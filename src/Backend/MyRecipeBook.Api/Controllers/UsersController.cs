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
        [HttpPost]
        public async Task<IActionResult> Register(
            [FromBody] RequestRegisterUserAccountJson request, 
            [FromServices] IRegisterUserAccountUseCase user)
        {
            await user.Execute(request);

            return Ok();
        }
    }
}