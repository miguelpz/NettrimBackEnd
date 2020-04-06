using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Cliente;
using NettrimCh.Api.Application.Contracts.ServiceContracts.TipoTarea;
using NettrimCh.Api.Application.Services;
using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaAdjuntosRepository;
using NettrimCh.Api.DataAccess.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Repositories.TareaAdjuntosRepository;
using NettrimCh.Api.DataAccess.Repositories.TipoTareaRepository;
using NettrimCh.Api.Domain.Factories.ClienteFactory;
using NettrimCh.Api.Domain.Services.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.Common;
using NettrimCh.Api.Domain.ServicesContracts.TareaAdjuntos;
using NettrimCh.Api.Domain.ServicesContracts.TipoTarea;
using NettrimCh.Api.Domain.ServicesImplementatios.Comon;
using NettrimCh.Api.Domain.ServicesImplementatios.TareaAdjuntos;
using NettrimCh.Api.Domain.ServicesImplementatios.TipoTarea;
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
            services.AddScoped<ITipoTareaRepository, TipoTareaRepository>();
            services.AddScoped<ITareaAdjuntosRepository, TareaAdjuntosRepository>();

           



            //Factorias
            //services.AddScoped<IClienteFactory, ClienteFactory>();

            //Specifications
            //services.AddScoped<IClienteSpecification, ClienteSpecification>();
            //services.AddScoped<IIsDNISpecification, IsDNISpecification>();
            //services.AddScoped<IIsEmailSpecification, IsEmailSpecification>();


            //Servicios
            services.AddScoped<IClienteDomainService, ClienteDomainService>();
            services.AddScoped<IClienteApplicationService, ClienteApplicationService>();
            services.AddScoped<ITipoTareaDomainService, TipoTareaDomainService>();
            services.AddScoped<ITipoTareaApplicationService, TipoTareaApplicationService>();
            services.AddScoped<ITareaAdjuntosDomainService, TareaAdjuntosDomainService>();

            services.AddScoped<IAttachFileService, AttachFileService>();






            services.AddDbContext<NettrimDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NettrimChConnection")));
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
