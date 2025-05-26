using Business.Abstract;
using Business.AutoMapper;
using Business.Concrete;
using Core.DataAccess.EntityFramework;
using Core.DataAccess;
using Core.DependencyResolvers;
using Core.Extensions;

using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using WebAPI.Swagger;
using DataAccess.Conrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
   
    public class Startup 
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var connectionString = Configuration.GetConnectionString("SqlServer");

            // DbContext qeydiyyatı edilir və connection string verilir
            services.AddDbContext<MilitaryBaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<DateOnlySchemaFilter>();
            });

            services.AddAutoMapper(typeof(MilitaryPersonelMapper));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:44362"));
            });
          

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey= SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                        
                    };
                   
                });
            services.AddDependencyResolvers(new Core.Utilities.IoC.ICoreModule[]
            {
                new CoreModule()
            });
        }

        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                app.UseSwagger();
                app.UseSwaggerUI(); 
            }
            app.ConfigureCustomExceptionMiddleware();

            app.UseRouting();

            app.UseStaticFiles();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();


          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
