using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

namespace WinUI3WithGenericHostSample;

public sealed class ApplicationHostedService(IHost host, IHostApplicationLifetime hostApplicationLifetime) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Application.Start(_ =>
        {
            var app = host.Services.GetRequiredService<App>();

            app.Exited += async (_, _) => await this.StopAsync(cancellationToken).ConfigureAwait(false);
        });
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        hostApplicationLifetime.StopApplication();
        return Task.CompletedTask;
    }
}
