using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sigma.Task.Core.Interfaces;
using Sigma.Task.Infrastructure.DataContext;
using Sigma.Task.Infrastructure.Repositories;

namespace Sigma.Task.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfratructureDI(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("SqliteConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
            );
            var dbContext = services.BuildServiceProvider().GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
            return services;
        }
    }
}
