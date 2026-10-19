using Microsoft.Playwright;
using Reqnroll;
using static Microsoft.Playwright.Assertions;

[Binding]
public class IniciarPartidaSteps
{
    private readonly IPage _page;

    public IniciarPartidaSteps(IPage page) => _page = page;

    [Given(@"que ingreso con la palabra ""(.*)""")]
    public async Task DadoQueIngresoConLaPalabra(string palabra)
        => await _page.GotoAsync($"{WebServerHooks.BaseUrl}/?word={palabra}");

    [Then(@"veo la palabra ""(.*)""")]
    public async Task EntoncesVeoLaPalabra(string esperada)
        => await Expect(_page.GetByTestId("word")).ToHaveTextAsync(esperada);

    [Then(@"veo (\d+) vidas")]
    public async Task EntoncesVeoVidas(int vidas)
        => await Expect(_page.GetByTestId("lives")).ToHaveTextAsync(vidas.ToString());
}