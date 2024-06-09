using SGE.Repositorios;
using SGE.UI.Components;
using SQLitePCL;
using SGE.Aplicacion;
var builder = WebApplication.CreateBuilder(args);
// consultar devolver enumerable o lista en los repositorios
// Add services to the container.
// verificar persimos en el caso de uso o en el frontend
// verificar hay un usuario con el mismo nombre 
// tirar autorizacion y validacionexception en casos de uso o sus respectivas clases?
builder.Services.AddRazorComponents().AddInteractiveServerComponents();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

SGESqlite.Inicializar();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
