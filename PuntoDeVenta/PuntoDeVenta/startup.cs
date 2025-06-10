using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PuntoDeVenta.Data;
using PuntoDeVenta.Services;
using System.Text;
using AutoMapper;
using PuntoDeVenta.Helpers;

namespace PuntoDeVenta
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Conexión a SQL Server
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<ProductoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IFacturaService, FacturaService>();
            services.AddDbContext<FacturaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IPedidoService, PedidoService>();
            services.AddDbContext<PedidoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IInventarioService, InventarioService>();
            services.AddDbContext<InventarioContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IOfertaService, OfertaService>();
            services.AddDbContext<OfertaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IDependienteService, DependienteService>();
            services.AddDbContext<DependienteContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AuditoriaContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            // Servicios propios
            services.AddTransient<IProductoService, ProductoService>();

            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhostFrontend", builder =>
                {
                    builder.WithOrigins("http://localhost:5173", "http://localhost:5174")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });


            // Controllers y Swagger
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PuntoDeVenta API",
                    Version = "v1"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PuntoDeVenta API v1");
                });
            }

            app.UseCors("AllowLocalhostFrontend");
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
