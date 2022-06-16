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

            var users = new List<User>()
            {
                new User
                {
                    Name = "User",
                    Email = "user@user.com",
                    Id = 1
                },
                new User
                {
                    Name = "User2",
                    Email = "user2@user.com",
                    Id = 2
                }
            };
            
            unitOfWork.Repository.AddRange(users);
            unitOfWork.Commit();

            var userCreated = unitOfWork.Repository.First<User>(user => user.Name == "User");
            var user2Created = unitOfWork.Repository.First<User>(user => user.Name == "User2");
            
            Console.WriteLine(userCreated?.Name);
            Console.WriteLine(user2Created?.Name);

            Console.WriteLine("-----------------");

            user2Created.Name = "UserNameEdited";

            unitOfWork.Commit();

            var usersCreatedNames = unitOfWork.Repository.Query<User>(user => true).Select(user => user.Name).ToList();
            usersCreatedNames.ForEach(userName => Console.WriteLine(userName));
            
            
        }

        static void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("fictDatabase"));
            services.AddTransient<IRepository, Repository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
        }
    }
}