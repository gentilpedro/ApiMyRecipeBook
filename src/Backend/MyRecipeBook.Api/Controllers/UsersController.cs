using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRegisterUserAccountUseCase _registerUserAccountUseCase;

        public UsersController(IRegisterUserAccountUseCase registerUserAccountUseCase)
        {
            _registerUserAccountUseCase = registerUserAccountUseCase;
        }

        [HttpPost("register")]
        public IActionResult Register(
            [FromBody] RequestRegisterUserAccountJson request, 
            [FromServices] IRegisterUserAccountUseCase user
            )
        {
            user.Execute(request);

            return Created();
        }
    }
}