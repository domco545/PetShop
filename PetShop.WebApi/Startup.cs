using Infrastructure.Authentication;
using Infrastructure.Data;
using Infrastructure.SQLite;
using Infrastructure.SQLite.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Impl;
using PetShop.Core.DomainService;
using PetShop.Core.DomainService.Impl;
using System;

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

            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            // Register the AuthenticationHelper in the helpers folder for dependency
            // injection. It must be registered as a singleton service. The AuthenticationHelper
            // is instantiated with a parameter. The parameter is the previously created
            // "secretBytes" array, which is used to generate a key for signing JWT tokens,
            services.AddSingleton<IAuthentication>(new
                Authentication(secretBytes));
            services.AddCors(options => options.AddPolicy("All", builder => builder.AllowAnyOrigin()
                                                                                    .AllowAnyMethod()
                                                                                    .AllowAnyHeader()));
            services.AddDbContext<PetShopDBContext>(opt => opt.UseSqlite("Data Source=petshop.db"));
            services.AddScoped<IPetRepository, PetSQLiteRepository>();
            services.AddScoped<IUserRepository, UserSQLiteRepository>(); 
            services.AddSingleton<IOwnerRepository, OwnerRepository>();
            services.AddSingleton<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IValidatorService, ValidatorService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IUserService, UserService>();
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

            // Use authentication
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
