using MySql.Data.MySqlClient;
using EventManagement.Repositories; // Asegúrate de que esta línea esté aquí


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuración de la conexión a la base de datos MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(connectionString));
builder.Services.AddTransient<EventRepository>(_ => new EventRepository(connectionString)); // Agrega esto

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Redireccionar la raíz a el controlador Event y la acción GetAllEvents
app.MapGet("/", async context =>
{
    context.Response.Redirect("/event/list"); // Cambia a /event/list o a lo que necesites
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Event}/{action=GetAllEvents}/{id?}");

app.Run();
