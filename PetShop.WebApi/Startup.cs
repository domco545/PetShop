using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.SQLite;
using Infrastructure.SQLite.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Impl;
using PetShop.Core.DomainService;
using PetShop.Core.DomainService.Impl;

namespace PetShop.WebApi
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
            services.AddCors(options => options.AddPolicy("All", builder => builder.AllowAnyOrigin()
                                                                                    .AllowAnyMethod()
                                                                                    .AllowAnyHeader()));
            services.AddDbContext<PetShopDBContext>(opt => opt.UseSqlite("Data Source=petshop.db"));
            services.AddScoped<IPetRepository, PetSQLiteRepository>();
            services.AddSingleton<IOwnerRepository, OwnerRepository>();
            services.AddSingleton<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IValidatorService, ValidatorService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IPetRepository petRepository, IOwnerRepository ownerRepository, IPetTypeRepository petTypeRepository)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopDBContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                }
                var data = new InitData(petRepository, ownerRepository, petTypeRepository);

            }

            app.UseCors("All");

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
