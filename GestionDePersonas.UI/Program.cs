using GestionDePersonas.BL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); //Conexion

builder.Services.AddDbContext<GestionDePersonas.DA.DBContexto>(options =>
    options.UseSqlServer(connectionString)); // en Base de Datos

//builder.Services.AddDbContext<GestionDePersonas.DA.DBContexto>(options =>
//    options.UseInMemoryDatabase("PersonasDB")); //En Memoria

builder.Services.AddScoped<GestionDePersonas.DA.IEmpleadoRepository, GestionDePersonas.DA.EmpleadoRepository>();
builder.Services.AddScoped<GestionDePersonas.DA.ICrearEmpleadoRepository, GestionDePersonas.DA.CrearEmpleadoRepository>();
builder.Services.AddScoped<GestionDePersonas.BL.IAdministradorDeEmpleados, GestionDePersonas.BL.AdministradorDeEmpleados>();
builder.Services.AddScoped<GestionDePersonas.DA.IUsuarioRepository, GestionDePersonas.DA.UsuarioRepository>();
builder.Services.AddScoped<AdminUsuarios>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
