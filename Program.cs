using Inscripciones.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
  

  // configuracion ... cadena de conexion.  
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json").Build();

// Add services to the container. configuracion SQLServer DBContext para que funcione en el controller
builder.Services.AddControllersWithViews();

// conexion a sqlServer
//builder.Services.AddDbContext<InscripcionesContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlserver")));
//"Server=127.0.0.1;Database=inscripcionescontext;User=root;Password=;";

// MySqlServer
//string cadenaConexion = configuration.GetConnectionString("mysql");
//builder.Services.AddDbContext<InscripcionesContext>(options => options.UseSqlServer(configuration.GetConnectionString("mysql")));

// conexion MySqlremoto
string cadenaConexion = configuration.GetConnectionString("mysqlremoto");
builder.Services.AddDbContext<InscripcionesContext>(options => options.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion),
    options => options.EnableRetryOnFailure(
                                        maxRetryCount: 5,
                                        maxRetryDelay: System.TimeSpan.FromSeconds(30),
                                       errorNumbersToAdd: null)
            ));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
});



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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
