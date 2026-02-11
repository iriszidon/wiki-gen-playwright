using Microsoft.Playwright;
using DotNetEnv;
using GenWikiTests.Helpers;
namespace GenWikiTests.Pages;


public class BasePage
{
    protected IPage _page;

    public BasePage(IPage page)
    {
        _page = page;
        string envFileDirectory = DirectoryUtils.GetNthParentDirectory(4);
        Console.WriteLine($"Loading .env File from Directory: {envFileDirectory}");
        Env.Load($"{envFileDirectory}\\.env"); // loads .env from project root
        Console.WriteLine($"BasePage initialized with URL: {Url}");
    }

    public string Url => Environment.GetEnvironmentVariable("BASE_URL");


    public Task NavigateAsync() => _page.GotoAsync(Url);

}