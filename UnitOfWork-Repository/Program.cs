using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWork_Repository.Data.Context;
using UnitOfWork_Repository.Data.Model;
using UnitOfWork_Repository.Data.Repository;
using UnitOfWork_Repository.Data.UnityOfWork;

namespace UnitOfWorkWithRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var servicesProvider = serviceCollection.BuildServiceProvider();

            var unitOfWork = servicesProvider.GetService<IUnitOfWork>();

            var user = new User
            {
                Name = "User",
                Email = "user@user.com",
                Id = 1
            };

            unitOfWork.Repository.Add(user);
            unitOfWork.Commit();

            var userCreated = unitOfWork.Repository.First<User>(user => user.Name == "User");
            
            Console.WriteLine(userCreated?.Name);
        }

        static void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("fictDatabase"));
            services.AddTransient<IRepository, Repository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
        }
    }
}