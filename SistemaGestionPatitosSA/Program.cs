using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); //Conexion

builder.Services.AddDbContext<GestionDePersonas.DA.DBContexto>(options =>
    options.UseSqlServer(connectionString)); // en Base de Datos

//builder.Services.AddDbContext<GestionDePersonas.DA.DBContexto>(options =>
//    options.UseInMemoryDatabase("PersonasDB")); //En Memoria


builder.Services.AddScoped<GestionDePersonas.DA.IEmpleadoRepository, GestionDePersonas.DA.EmpleadoRepository>();
builder.Services.AddScoped<GestionDePersonas.DA.ICrearEmpleadoRepository, GestionDePersonas.DA.CrearEmpleadoRepository>();
builder.Services.AddScoped<GestionDePersonas.BL.IAdministradorDeEmpleados, GestionDePersonas.BL.AdministradorDeEmpleados>();
builder.Services.AddScoped<GestionDePersonas.DA.IUsuarioRepository, GestionDePersonas.DA.UsuarioRepository>();


var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
