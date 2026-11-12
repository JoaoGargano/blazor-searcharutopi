using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SearchNarutoAPI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registra o HttpClient apontando para a Base URL da API do Naruto (Dattebayo API)
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://dattebayo-api.onrender.com/")
});

await builder.Build().RunAsync();
