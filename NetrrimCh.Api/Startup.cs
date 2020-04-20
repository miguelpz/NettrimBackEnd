using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Cliente;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Empleado;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Proyecto;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Tarea;
using NettrimCh.Api.Application.Contracts.ServiceContracts.TipoTarea;
using NettrimCh.Api.Application.Services;
using NettrimCh.Api.CrossCutting.Encriptado;
using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.EmpleadoRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ProyectoEmpleadoRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ProyectoRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaAdjuntosRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaRepository;
using NettrimCh.Api.DataAccess.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Repositories.EmpleadoRepository;
using NettrimCh.Api.DataAccess.Repositories.ProyectoEmpleadoRepository;
using NettrimCh.Api.DataAccess.Repositories.ProyectoRepository;
using NettrimCh.Api.DataAccess.Repositories.TareaAdjuntosRepository;
using NettrimCh.Api.DataAccess.Repositories.TareaRepository;
using NettrimCh.Api.DataAccess.Repositories.TipoTareaRepository;
using NettrimCh.Api.Domain.Factories.ClienteFactory;
using NettrimCh.Api.Domain.Services.Cliente;
using NettrimCh.Api.Domain.Services.Proyecto;
using NettrimCh.Api.Domain.Services.Tarea;
using NettrimCh.Api.Domain.ServicesContracts.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.Common;
using NettrimCh.Api.Domain.ServicesContracts.Empleado;
using NettrimCh.Api.Domain.ServicesContracts.Proyecto;
using NettrimCh.Api.Domain.ServicesContracts.Tarea;
using NettrimCh.Api.Domain.ServicesContracts.TareaAdjuntos;
using NettrimCh.Api.Domain.ServicesContracts.TipoTarea;
using NettrimCh.Api.Domain.ServicesImplementatios.Comon;
using NettrimCh.Api.Domain.ServicesImplementatios.Empleado;
using NettrimCh.Api.Domain.ServicesImplementatios.TareaAdjuntos;
using NettrimCh.Api.Domain.ServicesImplementatios.TipoTarea;
using NettrimCh.Api.Domain.Specifications.ClienteSpecification;
using NettrimCh.Api.Domain.Specifications.GlobalSpecifications;
using NettrimCh.Api.Domain.Specifications.GlobalSpecifications.DNISpecification;
using NettrimCh.Api.Domain.Specifications.GlobalSpecifications.EmailSpecification;
using System.IO;

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
                    builder.WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
            });

            
            //Encriptación
            services.AddDataProtection()
                .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration()
                {
                    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_GCM,
                    ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                });
               
            //Repositorios
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITipoTareaRepository, TipoTareaRepository>();
            services.AddScoped<ITareaAdjuntosRepository, TareaAdjuntosRepository>();
            services.AddScoped<ITareaRepository, TareaRepository>();
            services.AddScoped<IProyectoRepository, ProyectoRepository>();
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<IProyectoEmpleadoRepository, ProyectoEmpleadoRepository>();





            //Factorias
            //services.AddScoped<IClienteFactory, ClienteFactory>();

            //Specifications
            //services.AddScoped<IClienteSpecification, ClienteSpecification>();
            //services.AddScoped<IIsDNISpecification, IsDNISpecification>();
            //services.AddScoped<IIsEmailSpecification, IsEmailSpecification>();


            //Servicios Mantenimiento
            services.AddScoped<IClienteDomainService, ClienteDomainService>();
            services.AddScoped<IClienteApplicationService, ClienteApplicationService>();
            services.AddScoped<ITipoTareaDomainService, TipoTareaDomainService>();
            services.AddScoped<ITipoTareaApplicationService, TipoTareaApplicationService>();
            services.AddScoped<ITareaAdjuntosDomainService, TareaAdjuntosDomainService>();
            services.AddScoped<ITareaDomainService, TareaDomainService>();
            services.AddScoped<ITareaApplicationService, TareaApplicationService>();

            services.AddScoped<IEmpleadoApplicationService, EmpleadoApplicationService>();
            services.AddScoped<IEmpleadoDomainService, EmpleadoDomainService>();

            services.AddScoped<IProyectoApplicationService, ProyectoApplicationService>();
            services.AddScoped<IProyectoDomainService, ProyectoDomainService>();



            //Servicios Mantenimiento Transversales
            services.AddScoped<IAttachFileService, AttachFileService>();
            services.AddScoped<IAttachFileService, AttachFileService>();

            //Servicios Transversales
            services.AddScoped<ICipherService, CipherService>();







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

            

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "Uploads")),
                RequestPath = "/" + Configuration.GetValue<string>("GeneralParameters:FileRoot")
            });

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
