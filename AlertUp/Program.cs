using System.Text;
using AlertUp.Data;
using AlertUp.Model;
using AlertUp.Security;
using AlertUp.Security.Implements;
using FluentValidation;
using AlertUp.Configuration;
using Microsoft.EntityFrameworkCore;
using AlertUp.Validator;
using AlertUp.Service.Implements;
using AlertUp.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

namespace AlertUp { }

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });


        if (builder.Configuration["Enviroment:Start"] == "PROD")
        {
            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("secrets.json");

            var connectionString = builder.Configuration
            .GetConnectionString("ProdConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));
        }
        else
        {
            var connectionString = builder.Configuration
                .GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

        builder.Services.AddTransient<IValidator<Tema>, TemaValidator>();
        builder.Services.AddTransient<IValidator<Postagem>, PostagemValidator>();
        builder.Services.AddTransient<IValidator<User>, UserValidator>();
       
        builder.Services.AddScoped<ITemaService, TemaService>();
        builder.Services.AddScoped<IPostagemService, PostagemService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuthService, AuthService>();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            var key = Encoding.UTF8.GetBytes(Settings.Secret);
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Projeto AlertUp",
                Description = "Rede social de denúncias baseada na ODS 11.",
                Contact = new OpenApiContact
                {
                    Name = "AlertUp",
                    Email = "alertupods11@gmail.com",
                    Url = new Uri("https://github.com/AlertUp-Projeto-integrador-ODS-11")
                },
                License = new OpenApiLicense
                {
                    Name = "Acesse o GitHub",
                    Url = new Uri("https://github.com/AlertUp-Projeto-integrador-ODS-11")
                }
            });
            

            options.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Digite um Token JWT válido",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"

            });


            options.OperationFilter<AuthResponsesOperationFilter>();
        });


        builder.Services.AddFluentValidationRulesToSwagger();
          

            builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "MyPolicy",
            policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();
            });
        });

        var app = builder.Build();

        using (var scope = app.Services.CreateAsyncScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();
        }

            app.UseSwagger();
            app.UseSwaggerUI();


        app.UseCors("MyPolicy");
        
        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

