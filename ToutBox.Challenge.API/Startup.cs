using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ToutBox.Challenge.AppServices.Services;
using ToutBox.Challenge.Contracts.Services;
using ToutBox.Challenge.Correios;
using ToutBox.Challenge.Data;
using ToutBox.Challenge.DataContracts.Config;
using ToutBox.Challenge.Services.Contracts.Data;
using ToutBox.Challenge.Services.Contracts.ThirdPart;

namespace ToutBox.Challenge.API
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
            services.AddDbContextPool<ToutboxContext>(e =>
            {
                e.UseSqlServer(Configuration.GetConnectionString("ToutboxConnectionString"));
            });            

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ToutBox.Challenge.API", Version = "v1"});
            });
            services.AddTransient<ICalculateDeliveryPriceCommandHandler, CalculateDeliveryPriceCommandHandler>();
            services.AddTransient<IGetMostRecentsQueryHandler, GetMostRecentsQueryHandler>();
            services.AddTransient<IGetMostFrequentsZipCodesQueryHandler, GetMostFrequentsZipCodesQueryHandler>();
            services.AddSingleton<ICorreiosService, CorreiosService>();
            services.AddSingleton<IDefaultValuesConfig, DefaultValuesConfig>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToutBox.Challenge.API v1"));

            serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ToutboxContext>().Database.Migrate();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}