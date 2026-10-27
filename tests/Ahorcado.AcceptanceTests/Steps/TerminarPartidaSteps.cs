using Microsoft.Playwright;
using Reqnroll;
using static Microsoft.Playwright.Assertions;

[Binding]
public class TerminarPartidaSteps
{
    private readonly IPage _page;

    public TerminarPartidaSteps(IPage page) => _page = page;

    [Then(@"veo el resultado ""(.*)""")]
    public async Task EntoncesVeoElResultado(string esperado)
        => await Expect(_page.GetByTestId("result")).ToHaveTextAsync(esperado);
}