using Microsoft.Playwright;
using System.Threading.Tasks;
using DotNetEnv;
using GenWikiTests.Helpers;
namespace GenWikiTests.Pages;


public class BasePage
{
    private readonly IPage _page;

    public BasePage(IPage page)
    {
        _page = page;
        DebuggingFeaturesLink = _page.Locator("a:has-text(\"Debugging features\")");
        string envFileDirectory = DirectoryUtils.GetNthParentDirectory(4);
        Console.WriteLine($"envFileDirectory ------> : {envFileDirectory}");
        Env.Load($"{envFileDirectory}\\.env"); // loads .env from project root

    }

    public string Url => Environment.GetEnvironmentVariable("BASE_URL");

    public ILocator DebuggingFeaturesLink { get; }

    public Task NavigateAsync() => _page.GotoAsync(Url);

    public Task ClickDebuggingFeaturesAsync() => DebuggingFeaturesLink.ClickAsync();


}