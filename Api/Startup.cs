using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Roxosoft.Orders.Api.Helpers;

namespace Roxosoft.Orders.Api {
    public class Startup {
        private readonly string _webApiAllowSpecificOrigins = "_webApiAllowSpecificOrigins";
        
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddCors(options => {
                                 options.AddPolicy(_webApiAllowSpecificOrigins,
                                     builder => {
                                         builder.WithOrigins("https://localhost:5011",
                                             "http://localhost:5010")
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();;
                                     });
                             });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //зависимости приложения
            ApplicationStartupHelper.InjectDependencies(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseCors(_webApiAllowSpecificOrigins); 
            
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //накатываем миграцию если нужно
            ApplicationStartupHelper.DatabaseMigrate(app);
        }
    }
}