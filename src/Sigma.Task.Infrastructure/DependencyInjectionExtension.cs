using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sigma.Task.Core.Interfaces;
using Sigma.Task.Infrastructure.Cache;
using Sigma.Task.Infrastructure.DataContext;
using Sigma.Task.Infrastructure.Repositories;

namespace Sigma.Task.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("SqliteConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
            );
            services.AddMemoryCache();
            services.AddScoped<CandidateRepository>();
            services.AddScoped<CandidateCache>();
            services.AddScoped<ICandidateRepository>(x => 
                new CacheRepository(x.GetRequiredService<CandidateRepository>(),
                                        x.GetRequiredService<CandidateCache>()));
            var dbContext = services.BuildServiceProvider().GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
            return services;
        }
    }
}
