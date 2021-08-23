using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackOverflow.Application.Interfaces.Repositories;
using StackOverflow.Application.Interfaces.Utils;
using StackOverflow.Infrastructure.Persistence.Contexts;
using StackOverflow.Infrastructure.Persistence.Repositories;
using StackOverflow.Infrastructure.Persistence.Repository;

namespace StackOverflow.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
                services.UseInMemoryDatabase();
            else
                services.UseSqlServerDatabase(configuration);

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IPostRepository, PostRepository>();
        }


        private static void UseInMemoryDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("ApplicationDb"));
        }

        private static void UseSqlServerDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
    }
}
