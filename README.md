# App Eventos - Agenda 15

Aplicativo acadêmico de **Cadastro de Eventos** desenvolvido em **C# e XAML com .NET MAUI**, como atividade da Agenda 15 da ETEC. O projeto permite cadastrar um evento, calcular automaticamente a duração e o custo total e consultar um resumo em outra página.

| Informação | Dados |
| --- | --- |
| Aluno | **Jefferson Astuti Magalhães de Barros** |
| Curso | Técnico em Desenvolvimento de Sistemas |
| Disciplina | Desenvolvimento de Sistemas II |
| Atividade | Agenda 15 - Cadastro de Eventos |
| Ano | 2026 |
| Tecnologias | C#, XAML, .NET MAUI, .NET 10, Visual Studio 2026 |

## O que o aplicativo faz

- Cadastro do **nome do evento**, **local**, **datas de início e término**, **número de participantes** e **custo por participante**.
- Validação de campos obrigatórios, quantidade inteira e positiva de participantes, custo monetário válido e período coerente.
- Classe `Evento` na pasta `Models`, com `DateTime`, `TimeSpan` e propriedades calculadas.
- Transferência dos dados para a página de resumo por meio de `BindingContext`.
- Navegação assíncrona entre as páginas com `async` e `await`.
- Apresentação das datas em `dd/MM/yyyy` e dos valores em reais (`pt-BR`), utilizando propriedades formatadas e `StringFormat` no XAML.

O projeto é uma demonstração acadêmica. Não cadastra eventos em um servidor, não envia dados e não realiza cobranças reais.

## Exemplo de cálculo

Suponha um evento de **15/11/2026 a 17/11/2026**, com **25 participantes** e custo de **R$ 85,50 por participante**.

- Diferença entre as datas com `TimeSpan`: **2 dias**.
- Duração de realização incluindo as duas datas: **3 dias**.
- Custo total: `25 x 85,50 = R$ 2.137,50`.

A duração inclui o dia inicial e o dia final; o intervalo de `TimeSpan`, sem essa inclusão, também aparece no resumo para demonstrar o cálculo solicitado na atividade.

## Como executar no Windows

1. Abra o **Visual Studio 2026**, com o SDK **.NET 10** e a carga de trabalho **.NET MAUI** instalada.
2. Mantenha os arquivos da solução na mesma pasta, com o arquivo `AppEventos.sln` na raiz.
3. Abra **`AppEventos.sln`** no Visual Studio.
4. Aguarde a restauração das dependências.
5. Selecione o projeto **AppEventos** como projeto de inicialização, caso o Visual Studio solicite.
6. Escolha **Windows Machine** como destino e pressione **F5**.
7. Preencha os seis campos e clique em **Ver resumo do evento**. Confira a segunda tela e utilize **Editar evento** para retornar.

### Suporte opcional a Android

O destino padrão é Windows. Com a carga de trabalho Android do .NET MAUI instalada, o projeto inclui os arquivos de plataforma e pode ser compilado com `dotnet build AppEventos/AppEventos.csproj -p:EnableAndroid=true`.

## Estrutura principal

```text
AppEventos.sln
AppEventos/
  Models/
    Evento.cs                 Dados, TimeSpan, duração e custo total
    EventoCadastro.cs         Validação dos valores digitados
  Views/
    CadastroEventoPage.xaml   Formulário com seis campos
    CadastroEventoPage.xaml.cs
    ResumoEventoPage.xaml     Resumo vinculado ao BindingContext
    ResumoEventoPage.xaml.cs
  Resources/                   Ícone e imagem de abertura vetoriais
  Platforms/                   Inicialização Windows e Android
README.md
```

## Entrega da atividade

O fichário solicita o código-fonte no GitHub e um PDF com capturas da execução do aplicativo, ou um vídeo demonstrativo. O documento de evidências apresenta a tela inicial, o formulário preenchido e o resumo do evento com os cálculos.

## Referencia didatica

ETEC / Centro Paula Souza, Agenda 15 - Desenvolvimento de Sistemas II. Material disponibilizado na plataforma EaDTEC AVA.
