using BLL.Contracts;
using BLL.Implementation;
using DataAccess;
using DataAccess.Contracts;
using DataAccess.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.Add(new ServiceDescriptor(typeof(IAnimalCreateService), typeof(AnimalCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IAnimalGetService), typeof(AnimalGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IAnimalUpdateService), typeof(AnimalUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IAnimalDeleteService), typeof(AnimalDeleteService), ServiceLifetime.Scoped));

            services.Add(new ServiceDescriptor(typeof(IShelterValidateService), typeof(ShelterValidateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IShelterCreateService), typeof(ShelterCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IShelterGetService), typeof(ShelterGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IShelterDeleteService), typeof(ShelterDeleteService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IShelterUpdateService), typeof(ShelterUpdateService), ServiceLifetime.Scoped));

            services.Add(new ServiceDescriptor(typeof(IAnimalDataAccess), typeof(AnimalDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IShelterDataAccess), typeof(ShelterDataAccess), ServiceLifetime.Transient));

            services.AddDbContext<AnimalSherlterContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Database")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
