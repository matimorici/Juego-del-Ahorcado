using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;

[Binding]
public class PlaywrightHooks
{
    private static IPlaywright _playwright = null!;
    private IBrowser _browser = null!;

    [BeforeTestRun]
    public static async Task BeforeTestRun()
        => _playwright = await Playwright.CreateAsync();

    [BeforeScenario]
    public async Task BeforeScenario(IObjectContainer container)
    {
        _browser = await _playwright.Chromium.LaunchAsync();
        var page = await _browser.NewPageAsync();
        container.RegisterInstanceAs<IPage>(page);
    }

    [AfterScenario]
    public async Task AfterScenario() => await _browser.CloseAsync();

    [AfterTestRun]
    public static void AfterTestRun() => _playwright.Dispose();
}