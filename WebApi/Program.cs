
using Aplication.Mapping;
using Aplication.UseCases;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // 2. Conexión a Base de Datos
            // Configurado para usar SQL Server y buscar las migraciones en "Infraestructure"
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Infraestructure")));

            // 3. Inyección de Dependencias

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // Repositorios (Interfaces y sus implementaciones)
            builder.Services.AddScoped<IInmueble, InmuebleRepository>();
            builder.Services.AddScoped<IFoto, FotoRepository>();
            builder.Services.AddScoped<IUsuario, UsuarioRepository>();
            builder.Services.AddScoped<IRol, RolRepository>();

            // Casos de Uso (Lógica de Negocio)
            builder.Services.AddScoped<CrearInmueble>();
            builder.Services.AddScoped<SubirFoto>();
            builder.Services.AddScoped<SeleccionarFoto>();
            builder.Services.AddScoped<RegistrarUsuario>();
            builder.Services.AddScoped<CrearRol>();

            // Agrega los controladores
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}