using DAO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebUI.StartupConfigure
{
    public static class DependencyInjectionConfigure
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                services.AddTransient<IContatoDAO, DAO.SQLServer.ContatoDAO>();
                services.AddTransient<ITelefoneDAO, DAO.SQLServer.TelefoneDAO>();
            }
            else
            {
                services.AddTransient<IContatoDAO, DAO.SQLite.ContatoDAO>();
                services.AddTransient<ITelefoneDAO, DAO.SQLite.TelefoneDAO>();
            }
            return services;
        }
    }
}