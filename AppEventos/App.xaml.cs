using System.Globalization;
using AppEventos.Views;

namespace AppEventos;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("pt-BR");
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var navegacao = new NavigationPage(new CadastroEventoPage())
        {
            BarBackgroundColor = Color.FromArgb("#152B47"),
            BarTextColor = Colors.White
        };

        return new Window(navegacao)
        {
            Title = "App Eventos | ETEC - Agenda 15",
            Width = 620,
            Height = 920,
            MinimumWidth = 400,
            MinimumHeight = 620
        };
    }
}
