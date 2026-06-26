using MyRecipeBook.Communication.Requests;
using Mapster;
using MyRecipeBook.Exception;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Repository.User;
using MyrecipeBook.Domain.Repository;

namespace MyRecipeBook.Application.UseCases.User.Register
{
    public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserAccountUseCase(
            IPasswordHasher passwordHasher, 
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _passwordHasher = passwordHasher;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            
        }


        public async Task Execute(RequestRegisterUserAccountJson request)
        {
            ValidateAndThrowOnFailures(request);
            var user = request.Adapt<Domain.Entities.User>();
            user.Password = _passwordHasher.HashPassword(request.Password);

            await _userWriteOnlyRepository.Add(user);
            await _unitOfWork.Commit();

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