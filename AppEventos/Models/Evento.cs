using System.Globalization;

namespace AppEventos.Models;

/// <summary>
/// Dados do evento e calculos derivados utilizados na Agenda 15.
/// </summary>
public class Evento
{
    private static readonly CultureInfo CulturaBrasileira = CultureInfo.GetCultureInfo("pt-BR");

    public string Nome { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }
    public int NumeroParticipantes { get; set; }
    public string Local { get; set; } = string.Empty;
    public decimal CustoPorParticipante { get; set; }

    // DateTime e TimeSpan: diferenca exata entre as duas datas, em dias.
    public TimeSpan Intervalo => DataTermino.Date - DataInicio.Date;

    // Dias de realizacao: inclui o primeiro e o ultimo dia do evento.
    public int DuracaoDias => Intervalo.Days + 1;

    public decimal CustoTotal => NumeroParticipantes * CustoPorParticipante;

    public string DataInicioFormatada => DataInicio.ToString("dd/MM/yyyy", CulturaBrasileira);
    public string DataTerminoFormatada => DataTermino.ToString("dd/MM/yyyy", CulturaBrasileira);
    public string IntervaloFormatado => $"{Intervalo.Days} dia(s) entre as datas";
    public string DuracaoFormatada => $"{DuracaoDias} dia(s) de evento";
    public string CustoPorParticipanteFormatado => CustoPorParticipante.ToString("C2", CulturaBrasileira);
    public string CustoTotalFormatado => CustoTotal.ToString("C2", CulturaBrasileira);
}
