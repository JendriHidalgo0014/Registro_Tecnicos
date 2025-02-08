using Registro_Tecnicos.Components;
using Registro_Tecnicos.DAL;
using Registro_Tecnicos.Models;
using Microsoft.EntityFrameworkCore;
using Registro_Tecnicos.Services;
using BlazorBootstrap;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Obtenemos el constructor para usarlo en el contexto.
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

//Agregamos el contexto al builder con el ConStr.
builder.Services.AddDbContextFactory<Context>(Options => Options.UseSqlServer(ConStr));
builder.Services.AddBlazorBootstrap();

//Inyeccion del service.
builder.Services.AddScoped<TecnicosService>();
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<TicketsService>();
builder.Services.AddScoped<SistemasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
