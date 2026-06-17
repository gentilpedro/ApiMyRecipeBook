using MyRecipeBook.Application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;

namespace MyRecipeBook.Application;

public class DependencyInjectionExtension
{
    public static void AddApplication(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserAccountUseCase, RegisterUserAccountUseCase>();
    }
}