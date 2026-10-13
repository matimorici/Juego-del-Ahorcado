using System.Diagnostics;
using Reqnroll;

[Binding]
public class WebServerHooks
{
    public const string BaseUrl = "http://localhost:5020";
    private static Process? _web;

    [BeforeTestRun]
    public static async Task StartWeb()
    {
        var web = Path.Combine(FindRepoRoot(), "src", "Ahorcado.Web");
        _web = Process.Start(new ProcessStartInfo("dotnet", $"run --project \"{web}\" --no-launch-profile")
        {
            Environment = { ["ASPNETCORE_URLS"] = BaseUrl, ["ASPNETCORE_ENVIRONMENT"] = "Development" }
        })!;

        using var http = new HttpClient();
        var deadline = DateTime.UtcNow.AddSeconds(60);
        while (DateTime.UtcNow < deadline)
        {
            if (_web.HasExited) throw new Exception("Ahorcado.Web terminó antes de responder.");
            try { if ((await http.GetAsync(BaseUrl)).IsSuccessStatusCode) return; }
            catch (HttpRequestException) { }
            await Task.Delay(500);
        }
        throw new TimeoutException("Ahorcado.Web no respondió 200 en 60 s.");
    }

    [AfterTestRun]
    public static void StopWeb() => _web?.Kill(entireProcessTree: true);

    private static string FindRepoRoot()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null && !File.Exists(Path.Combine(dir.FullName, "Ahorcado.slnx"))) dir = dir.Parent;
        return dir?.FullName ?? throw new DirectoryNotFoundException("No encontré Ahorcado.slnx");
    }
}