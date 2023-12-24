using Application.DistributorManagement.Commands.Create;
using Application.Shared.Services.ProductServices;
using Domain.DistributorManagement.Repository;
using Domain.ProductManagement.Repository;
using Domain.SaleManagement.Repository;
using Domain.Shared;
using FluentValidation;
using Infrastructure.DataAccess;
using Infrastructure.Repositories.DistributorManagement;
using Infrastructure.Repositories.ProductManagement;
using Infrastructure.Repositories.SaleManagement;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace N_M_S.Api
{
    public class DependencyResolver
    {
        private string? _dbConnection;

        public DependencyResolver(IConfiguration configuration)
        {
            _dbConnection = configuration.GetConnectionString("MyWebApiConection");
        }

        public IServiceCollection Resolve(IServiceCollection services)
        {
            if (services == null)
            {
                services = new ServiceCollection();
            }

            services.AddScoped<IDistributorRepository, DistributorRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();  

            services.AddDbContext<EFDbContext>(opt =>
                 opt.UseSqlServer(_dbConnection).UseLazyLoadingProxies());

            services.AddMediatR(new[]
            {
                 typeof(CreateDistributorCommand).GetTypeInfo().Assembly,
            });

            services.AddValidatorsFromAssembly(typeof(CreateDistributorCommand).GetTypeInfo().Assembly);

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(); ;

            return services;
        }
    }
}
