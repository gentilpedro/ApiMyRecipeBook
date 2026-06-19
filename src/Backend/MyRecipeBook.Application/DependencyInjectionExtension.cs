using MyRecipeBook.Application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;

namespace MyRecipeBook.Application;

public static class DependencyInjectionExtension
{
    extension(IServiceCollection services)
    {
        public void AddApplication()
        {
            services.AddScoped<IRegisterUserAccountUseCase, RegisterUserAccountUseCase>();
        }
    }

}