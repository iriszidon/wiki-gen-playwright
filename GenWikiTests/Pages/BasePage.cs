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
        string currentDirectory = DirectoryUtils.GetCurrentDirectory();
        string parentDirectory = DirectoryUtils.GetParentDirectory(currentDirectory);
        string levelTwoDirectory = DirectoryUtils.GetParentDirectory(parentDirectory);
        string levelTreeDirectory = DirectoryUtils.GetParentDirectory(levelTwoDirectory);
        string levelFourDirectory = DirectoryUtils.GetParentDirectory(levelTreeDirectory);
        Console.WriteLine($"levelFourDirectory: {levelFourDirectory}");
        Env.Load($"{levelFourDirectory}\\.env"); // loads .env from project root

    }

    public string Url => Environment.GetEnvironmentVariable("BASE_URL");

    public ILocator DebuggingFeaturesLink { get; }

    public Task NavigateAsync() => _page.GotoAsync(Url);

    public Task ClickDebuggingFeaturesAsync() => DebuggingFeaturesLink.ClickAsync();


}