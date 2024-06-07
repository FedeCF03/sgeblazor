using SGE.Repositorios;
using SGE.UI.Components;
using SQLitePCL;
using SGE.Aplicacion;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton < IExpedienteRepositorio, ();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();
;
SGESqlite.Inicializar();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
