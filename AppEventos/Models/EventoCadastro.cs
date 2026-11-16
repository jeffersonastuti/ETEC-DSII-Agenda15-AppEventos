using System.Globalization;

namespace AppEventos.Models;

/// <summary>
/// Transforma os campos da tela em um Evento valido, sem depender da interface MAUI.
/// </summary>
public static class EventoCadastro
{
    private static readonly CultureInfo CulturaBrasileira = CultureInfo.GetCultureInfo("pt-BR");

    public static bool TentarCriar(
        string? nome,
        DateTime dataInicio,
        DateTime dataTermino,
        string? participantesTexto,
        string? local,
        string? custoTexto,
        out Evento? evento,
        out string erro)
    {
        evento = null;
        erro = string.Empty;

        string nomeLimpo = nome?.Trim() ?? string.Empty;
        string localLimpo = local?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(nomeLimpo))
        {
            erro = "Informe o nome do evento.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(localLimpo))
        {
            erro = "Informe o local do evento.";
            return false;
        }

        if (dataTermino.Date < dataInicio.Date)
        {
            erro = "A data de término não pode ser anterior à data de início.";
            return false;
        }

        if (!int.TryParse(participantesTexto?.Trim(), NumberStyles.None,
                CultureInfo.InvariantCulture, out int numeroParticipantes) ||
            numeroParticipantes < 1 || numeroParticipantes > 100000)
        {
            erro = "Informe uma quantidade inteira de participantes entre 1 e 100.000.";
            return false;
        }

        if (!decimal.TryParse(custoTexto?.Trim(), NumberStyles.Currency,
                CulturaBrasileira, out decimal custo) ||
            custo <= 0 || custo > 1000000m || custo != decimal.Round(custo, 2))
        {
            erro = "Informe um custo positivo de até R$ 1.000.000,00, com no máximo duas casas decimais.";
            return false;
        }

        evento = new Evento
        {
            Nome = nomeLimpo,
            DataInicio = dataInicio.Date,
            DataTermino = dataTermino.Date,
            NumeroParticipantes = numeroParticipantes,
            Local = localLimpo,
            CustoPorParticipante = custo
        };

        return true;
    }
}
