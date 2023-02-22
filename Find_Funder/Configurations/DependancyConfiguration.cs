using FindFunder.Core.Contract;
using FindFunder.Core.Service;
using FindFunder.Infra.Contract;
using FindFunder.Infra.Repository;
using System.Runtime.CompilerServices;

namespace Find_Funder.Configurations
{
    public static class DependancyConfiguration
    {
        public static void AddDependancy(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IStateService, StateService>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
