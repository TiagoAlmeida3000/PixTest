using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PixTest.Application.Interfaces;
using PixTest.Application.Services;
using PixTest.Domain.Interfaces;
using PixTest.Infra.Data.Context;
using PixTest.Infra.Data.Repositories;

namespace PixTest.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddTransient<ApplicationDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ITransferRepository, TransferRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITransferService, TransferService>();

            return services;
        }
    }
}
