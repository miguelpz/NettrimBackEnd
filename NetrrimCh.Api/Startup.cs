using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Cliente;
using NettrimCh.Api.Application.Services;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.CodigoOtRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.Recursorepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TablaTipoTareaRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaRepository;

using NettrimCh.Api.DataAccess.Contracts.Repositories.UsuarioOtsRepository;
using NettrimCh.Api.DataAccess.Models;
using NettrimCh.Api.DataAccess.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Repositories.CodigoOtRepository;
using NettrimCh.Api.DataAccess.Repositories.RecursoRepository;
using NettrimCh.Api.DataAccess.Repositories.TablaTipoTareaRepository;
using NettrimCh.Api.DataAccess.Repositories.TareaRepository;
using NettrimCh.Api.DataAccess.Repositories.UsuarioOtsRepository;
using NettrimCh.Api.Domain.Factories.ClienteFactory;
using NettrimCh.Api.Domain.Services.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.Cliente;
using NettrimCh.Api.Domain.Specifications.ClienteSpecification;
using NettrimCh.Api.Domain.Specifications.GlobalSpecifications;
using NettrimCh.Api.Domain.Specifications.GlobalSpecifications.DNISpecification;
using NettrimCh.Api.Domain.Specifications.GlobalSpecifications.EmailSpecification;

namespace NetrrimCh.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200");
                });
            });

            //Repositorios
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICodigoOtRepository, CodigoOtRepository>();
            services.AddScoped<IRecursoRepository, RecursoRepository>();
            services.AddScoped<ITablaTipoTareaRepository, TablaTipoTareaRepository>();
            services.AddScoped<ITareaRepository, TareaRepository>();
            services.AddScoped<IUsuarioOtsRepository, UsuarioOtsRepository>();

            //Factorias
            services.AddScoped<IClienteFactory, ClienteFactory>();

            //Specifications
            services.AddScoped<IClienteSpecification, ClienteSpecification>();
            services.AddScoped<IIsDNISpecification, IsDNISpecification>();
            services.AddScoped<IIsEmailSpecification, IsEmailSpecification>();
            services.AddScoped<INotNullSpecification, NotNullSpecification>();

            //Servicios
            services.AddScoped<IClienteDomainService, ClienteDomainService>();
            services.AddScoped<IClienteApplicationService, ClienteApplicationService>();






            services.AddDbContext<NettrimChContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NettrimChConnection")));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
