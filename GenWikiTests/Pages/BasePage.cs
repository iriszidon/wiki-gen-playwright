using Microsoft.Playwright;
using System.Threading.Tasks;
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
        Console.WriteLine($"envFileDirectory ------> : {envFileDirectory}");
        Env.Load($"{envFileDirectory}\\.env"); // loads .env from project root

    }

    public string Url => Environment.GetEnvironmentVariable("BASE_URL");


    public Task NavigateAsync() => _page.GotoAsync(Url);

}