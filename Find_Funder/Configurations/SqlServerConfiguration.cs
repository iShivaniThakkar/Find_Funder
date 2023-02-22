using FindFunder.Infra.Domain;
using Microsoft.EntityFrameworkCore;

namespace Find_Funder.Configurations
{
    public static class SqlServerConfiguration
    {
        public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultConn"];

            services.AddDbContext<FindFunderContext>(options =>
            {

                options.UseSqlServer(connectionString, x =>
                {
                    x.MigrationsAssembly("FindFunder.Infra.Domain");
                    x.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });

            }, ServiceLifetime.Singleton);
        }
    }
}
