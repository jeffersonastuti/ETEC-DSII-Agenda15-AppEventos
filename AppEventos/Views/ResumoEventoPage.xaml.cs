namespace AppEventos.Views;

public partial class ResumoEventoPage : ContentPage
{
    public ResumoEventoPage()
    {
        InitializeComponent();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
