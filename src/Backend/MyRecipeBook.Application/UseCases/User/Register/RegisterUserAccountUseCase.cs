using MyRecipeBook.Communication.Requests;
using Mapster;
using MyRecipeBook.Exception;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Domain.Repository.User;
using MyrecipeBook.Domain.Repository;
using MyRecipeBook.Communication.Responses;
using FluentValidation.Results;

namespace MyRecipeBook.Application.UseCases.User.Register
{
    public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserAccountUseCase(
            IPasswordHasher passwordHasher,
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IUserReadOnlyRepository userReadOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _passwordHasher = passwordHasher;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserAccountJson request)
        {
            ValidateAndThrowOnFailures(request);
            var user = request.Adapt<Domain.Entities.User>();
            user.Password = _passwordHasher.HashPassword(request.Password);

            await _userWriteOnlyRepository.Add(user);
            await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                Tokens = new ResponseTokensJson()
            };

        }

        private async Task ValidateAndThrowOnFailures(RequestRegisterUserAccountJson request)
        {
            var validator = new RegisterUserAccountValidator();
            var validationResult = validator.Validate(request);

            var emailExist = await _userReadOnlyRepository.ExistActiveUserEmail(request.Email);
            if (emailExist)
            {
                validationResult.Errors.Add(new ValidationFailure(string.Empty, ResourceMessagesException.VALIDATION_EMAIL_ALREADY_EXISTS));
            }

            if (validationResult.IsValid == false)
            {
                var errorsMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorsMessages);
            }
        }

    }
}