using Microsoft.Playwright;
using System.Threading.Tasks;
using DotNetEnv;
namespace GenWikiTests.Pages;


public class BasePage
{
    private readonly IPage _page;

    public BasePage(IPage page)
    {
        _page = page;
        DebuggingFeaturesLink = _page.Locator("a:has-text(\"Debugging features\")");
        string currentDirectory = GetCurrentDirectory();
        string parentDirectory = GetParentDirectory(currentDirectory);
        string levelTwoDirectory = GetParentDirectory(parentDirectory);
        string levelTreeDirectory = GetParentDirectory(levelTwoDirectory);
        string levelFourDirectory = GetParentDirectory(levelTreeDirectory);
        Console.WriteLine($"levelFourDirectory: {levelFourDirectory}");
        Env.Load($"{levelFourDirectory}\\.env"); // loads .env from project root

    }

    public string Url => Environment.GetEnvironmentVariable("BASE_URL");

    public ILocator DebuggingFeaturesLink { get; }

    public Task NavigateAsync() => _page.GotoAsync(Url);

    public Task ClickDebuggingFeaturesAsync() => DebuggingFeaturesLink.ClickAsync();


    // Returns the current directory of the application
    private string GetCurrentDirectory()
    {
        return Directory.GetCurrentDirectory();
    }

    // Receives a directory path and returns its parent directory
    private string GetParentDirectory(string directoryPath)
    {
        if (string.IsNullOrEmpty(directoryPath))
            throw new ArgumentException("Directory path cannot be null or empty.", nameof(directoryPath));

        var parent = Directory.GetParent(directoryPath);
        return parent?.FullName ?? string.Empty;
    }

}