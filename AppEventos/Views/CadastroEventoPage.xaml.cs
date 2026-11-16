using AppEventos.Models;

namespace AppEventos.Views;

public partial class CadastroEventoPage : ContentPage
{
    public CadastroEventoPage()
    {
        InitializeComponent();

        // BindingContext permite que os campos de texto e datas sejam vinculados a um model.
        BindingContext = new Evento
        {
            DataInicio = DateTime.Today,
            DataTermino = DateTime.Today.AddDays(1)
        };

        dtp_termino.MinimumDate = DateTime.Today;
    }

    private void OnInicioDateSelected(object sender, DateChangedEventArgs e)
    {
        if (e.NewDate is not DateTime inicio)
            return;

        dtp_termino.MinimumDate = inicio.Date;
        if (dtp_termino.Date is DateTime termino && termino.Date < inicio.Date)
            dtp_termino.Date = inicio.Date;
    }

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        if (dtp_inicio.Date is not DateTime inicio || dtp_termino.Date is not DateTime termino)
        {
            await DisplayAlertAsync("Datas obrigatórias", "Informe as datas de início e término.", "OK");
            return;
        }

        if (!EventoCadastro.TentarCriar(
                ent_nome.Text, inicio, termino,
                ent_participantes.Text, ent_local.Text, ent_custo.Text,
                out Evento? evento, out string erro) || evento is null)
        {
            await DisplayAlertAsync("Confira o cadastro", erro, "OK");
            return;
        }

        try
        {
            // O objeto completo segue para a segunda pagina via BindingContext.
            await Navigation.PushAsync(new ResumoEventoPage
            {
                BindingContext = evento
            });
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Não foi possível abrir o resumo", ex.Message, "OK");
        }
    }

    private void OnLimparClicked(object sender, EventArgs e)
    {
        ent_nome.Text = string.Empty;
        ent_local.Text = string.Empty;
        ent_participantes.Text = "1";
        ent_custo.Text = string.Empty;
        dtp_inicio.Date = DateTime.Today;
        dtp_termino.MinimumDate = DateTime.Today;
        dtp_termino.Date = DateTime.Today.AddDays(1);
    }
}
