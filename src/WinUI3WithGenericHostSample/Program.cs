using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinUI3WithGenericHostSample;

Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<ApplicationHostedService>();
builder.Services.AddSingleton<App>();
builder.Services.AddTransient<MainWindow>();

var app = builder.Build();

app.Run();
