using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

namespace WinUI3WithGenericHostSample;

public partial class App : Application
{
    private readonly IServiceScope serviceScope;

    public App(IServiceScope serviceScope)
    {
        this.serviceScope = serviceScope;
        this.InitializeComponent();
    }

    public event EventHandler? Exited;

    public Window? MainWindow { get; private set; }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        this.MainWindow = this.serviceScope.ServiceProvider.GetRequiredService<MainWindow>();
        this.MainWindow.Closed += (_, _) => this.Exited?.Invoke(this, EventArgs.Empty);
        this.MainWindow.Activate();
    }
}
