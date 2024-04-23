using Microsoft.EntityFrameworkCore;
using pruebaHame.BLL.Service;
using pruebaHame.DAL.DataContext;
using pruebaHame.DAL.Repositories;
using pruebaHame.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//agregamos una referencia a nuestro dbContextSQL Server
builder.Services.AddDbContext<pruebaHAMEContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

//Realizamos inyeccion de Dependencias para que el controlador las pueda ver
builder.Services.AddScoped<IGenericRepository<Cliente>,clienteGenericRepository>();
builder.Services.AddScoped<IClienteService, clienteService>();
//inyectamos las dependencias de la entidad Servicio
builder.Services.AddScoped<IGenericRepository<Servicio>, servicioRepository>();
builder.Services.AddScoped<IServicioService, servicioService>();

//inyectamos las dependencias de la entidad Servicio
builder.Services.AddScoped<IGenericRepository<ClienteServicio>, serviciosAsociadosRepository>();
builder.Services.AddScoped<IServiciosAsociadosService, servicioAsociadoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
