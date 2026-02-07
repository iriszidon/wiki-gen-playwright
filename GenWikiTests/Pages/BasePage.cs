using Microsoft.Playwright;
using System.Threading.Tasks;

namespace GenWikiTests.Pages;

public class BasePage
{
    private readonly IPage _page;

    public BasePage(IPage page)
    {
        _page = page;
        DebuggingFeaturesLink = _page.Locator("a:has-text(\"Debugging features\")");
    }

    public string Url => "https://en.wikipedia.org/wiki/Playwright_(software)";

    public ILocator DebuggingFeaturesLink { get; }

    public Task NavigateAsync() => _page.GotoAsync(Url);

    public Task ClickDebuggingFeaturesAsync() => DebuggingFeaturesLink.ClickAsync();
}