using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PizzaPH;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Services
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Your app service (pizza specials)
builder.Services.AddScoped<PizzaPH.Data.SpecialsService>();

// Set app-wide culture to Philippines
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-PH");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-PH");

await builder.Build().RunAsync();
