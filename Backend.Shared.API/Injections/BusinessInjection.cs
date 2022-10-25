using Backend.Shared.BusinessRules;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.Interface.Repository;
using Backend.Shared.Repositories;
using Backend.Shared.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Shared.API.Injections
{
    /// <summary>
    /// Business Injection
    /// </summary>
    public static class BusinessInjection
    {
        /// <summary>
        /// Adds the business configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration"></param>
        public static void AddBusinessConfig(this IServiceCollection services, IConfiguration configuration)
        {
            

            services.AddDbContext<dbaeusdsdevpamecContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            
            // inyeccion de repository
            services.AddScoped(typeof(IConstantesRepository), typeof(ConstantesRepository));
           


            // inyeccion de business rules
            
            services.AddTransient<IConstantesBusiness, ConstantesBusiness>();
            
            

        }
    }
}
