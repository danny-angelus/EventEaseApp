using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EventEaseApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<EventEaseApp.Services.EventService>();
builder.Services.AddScoped<EventEaseApp.Services.UserSessionService>();
builder.Services.AddSingleton<EventEaseApp.Services.AttendanceService>();

await builder.Build().RunAsync();
