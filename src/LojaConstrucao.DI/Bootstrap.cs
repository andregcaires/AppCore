using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LojaConstrucao.Data;
using LojaConstrucao.Domain.Products;
using LojaConstrucao.Domain;

namespace LojaConstrucao.DI
{
    // classe inicializadora do Injetor de Dependências
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string conn)
        {
            // configura todos os servicos de injeção de dependencia de todas as camadas
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(conn));
            
            
            services.AddSingleton(typeof(IRepository<>), typeof(IRepository<>));
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}