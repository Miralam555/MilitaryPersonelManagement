

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.AutoMapper;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Conrete.EntityFramework.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using WebAPI.Swagger;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Autofac üçün
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterModule(new AutofacBusinessModule());
            });

            // Konfiqurasiya oxuma
            var configuration = builder.Configuration;

            // Servisləri əlavə et
            builder.Services.AddControllers();

            var connectionString = configuration.GetConnectionString("SqlServer");
            builder.Services.AddDbContext<MilitaryBaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Singleton);
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<DateOnlySchemaFilter>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme="bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                    {
                        Reference=new OpenApiReference
                        {
                            Id="Bearer",
                            Type=ReferenceType.SecurityScheme
                        }
                    },new List<String> ()}
                });
            });

            builder.Services.AddAutoMapper(typeof(MilitaryPersonelMapper));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:44362"));
            });

           
            var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
            builder.Services.AddDependencyResolvers(new ICoreModule[]
            {
                 new CoreModule()
            });

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

           
            app.UseCustomExceptionMiddleware();
            

           
            app.UseRouting();

            
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();


        }

      
    }
}
