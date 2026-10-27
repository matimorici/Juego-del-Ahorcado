using Microsoft.Playwright;
using Reqnroll;
using static Microsoft.Playwright.Assertions;
using System.Text.RegularExpressions;

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

    [When(@"adivino la letra ""(.*)""")]
    public async Task CuandoAdivinoLaLetra(string letra)
    {
        var campo = _page.GetByRole(AriaRole.Textbox);
        await campo.FillAsync(letra);
        await campo.PressAsync("Enter");
    }
    
    [Given(@"que ingreso sin indicar una palabra")]
    public async Task DadoQueIngresoSinIndicarUnaPalabra()
        => await _page.GotoAsync(WebServerHooks.BaseUrl);

    [Then(@"veo una palabra oculta")]
    public async Task EntoncesVeoUnaPalabraOculta()
        => await Expect(_page.GetByTestId("word")).ToHaveTextAsync(new Regex(@"^_( _)*$"));

    [Then(@"veo el mensaje ""(.*)""")]
    public async Task EntoncesVeoElMensaje(string esperado)
        => await Expect(_page.GetByTestId("message")).ToHaveTextAsync(esperado);
}