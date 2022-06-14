using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWork_Repository.Data.Context;
using UnitOfWork_Repository.Data.Model;
using UnitOfWork_Repository.Data.Repository;

namespace UnitOfWorkWithRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var servicesProvider = serviceCollection.BuildServiceProvider();

            var userRepository = servicesProvider.GetService<IUserRepository>();

            var user = new User
            {
                Name = "User",
                Email = "user@user.com",
                Id = 1
            };

            userRepository?.Add(user);

            var userCreated = userRepository?.Find(1);
            Console.WriteLine(userCreated?.Name);
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>()
                .AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("fictDatabase"));
            
        }
    }
}