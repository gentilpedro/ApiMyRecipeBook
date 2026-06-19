using MyRecipeBook.Communication.Requests;
using Mapster;
using MyRecipeBook.Exception;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Domain.Extensions;

namespace MyRecipeBook.Application.UseCases.User.Register
{
    public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
    {
        private readonly IPasswordHasher _passwordHasher;
        public RegisterUserAccountUseCase(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public void Execute(RequestRegisterUserAccountJson request)
        {
            if (request.Email.IsNotEmpty())
            {
                request.Email.Trim();
            }

            ValidateAndThrowOnFailures(request);

            var user = request.Adapt<Domain.Entities.User>();

            user.Password = _passwordHasher.HashPassword(request.Password);

        }

        private void ValidateAndThrowOnFailures(RequestRegisterUserAccountJson request)
        {
            var validator = new RegisterUserAccountValidator();
            var validationResult = validator.Validate(request);
            if (validationResult.IsValid == false)
            {
                var errorsMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorsMessages);
            }
        }

    }
}