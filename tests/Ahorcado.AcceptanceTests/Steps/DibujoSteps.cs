using Microsoft.Playwright;
using Reqnroll;
using static Microsoft.Playwright.Assertions;

[Binding]
public class DibujoSteps
{
    private readonly IPage _page;

    public DibujoSteps(IPage page) => _page = page;

    [Then(@"veo el dibujo ""(.*)""")]
    public async Task EntoncesVeoElDibujo(string esperado)
        => await Expect(_page.GetByTestId("figure")).ToHaveTextAsync(esperado);

    [Then(@"no veo partes del dibujo")]
    public async Task EntoncesNoVeoPartesDelDibujo()
        => await Expect(_page.GetByTestId("figure")).ToBeEmptyAsync();
}