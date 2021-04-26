using DAO;
using Microsoft.Extensions.DependencyInjection;

namespace WebUI.StartupConfigure
{
    public static class DependencyInjectionConfigure
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IContatoDAO, DAO.SQLServer.ContatoDAO>();
            services.AddTransient<ITelefoneDAO, DAO.SQLServer.TelefoneDAO>();

            return services;
        }
    }
}