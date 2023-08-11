using Andreitoledo.GeekShopping.CartAPI.Config;
using Andreitoledo.GeekShopping.CartAPI.Model.Context;
using Andreitoledo.GeekShopping.CartAPI.RabbitMQSender;
using Andreitoledo.GeekShopping.CartAPI.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Andreitoledo.GeekShopping.CartAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Conex�o com o banco MySQL
            var connection = builder.Configuration["MySqlConnection:MySqlConnectionString"];
            builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
                connection,
                new MySqlServerVersion(new Version(8, 0, 0))));


            // Adiciona a classe MappingConfig - andrei
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Injeta o productrepository - andrei
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<ICouponRepository, CouponRepository>();

            builder.Services.AddSingleton<IRabbitMQMessageSender, RabbitMQMessageSender>();

            builder.Services.AddAuthorization();

            builder.Services.AddControllers();

            builder.Services.AddHttpClient<ICouponRepository, CouponRepository>(s => s.BaseAddress =
                new Uri(builder.Configuration["ServiceUrls:CouponAPI"]));

            // Configura��es de Autentica��o e Autoriza��o
            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:4435/";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "geek_shopping");
                });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            // Ajuste no titulo - andrei
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping.CartAPI", Version = "v1" });                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Digite 'Bearer' [space] e o seu token!",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In= ParameterLocation.Header
                        },
                        new List<string> ()
                    }
                 });

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}