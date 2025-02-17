
using Infrastructure.Data;
using Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

namespace CompuShareAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)), ServiceLifetime.Scoped);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // Add a security scheme definition to Swagger
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });


                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CompuShare api",
                    Description = "Web API for managing CompuShare APIs",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License",
                        Url = new Uri("https://example.com/license")
                    },


                });
                options.OperationFilter<FileUploadOperationFilter>();
                // Add a global security requirement to Swagger
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });

                // Add other Swagger configuration here...
            });

           builder.Services.InfrastructureServices(builder.Configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "CompuShareWeb", configurePolicy: policyBuilder =>
                {
                    policyBuilder.WithOrigins("http://localhost:3000");
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                    policyBuilder.AllowCredentials();

                });


            });
            //builder.Services.ServiceContainer;
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Student",policy => policy.RequireClaim(ClaimTypes.Role));
                options.AddPolicy("Admin",policy => policy.RequireClaim(ClaimTypes.Role));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();

            app.MapControllers();
            app.UseCors("CompuShareWeb");

            app.Run();
        }
    }
}
