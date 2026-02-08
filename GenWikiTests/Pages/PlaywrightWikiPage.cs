using Microsoft.Playwright;
using System.Threading.Tasks;

namespace GenWikiTests.Pages;

public class PlaywrightWikiPage : BasePage
{
    public PlaywrightWikiPage(IPage page) : base(page)
    {
        DebuggingFeaturesLink = page.Locator("a:has-text(\"Debugging features\")");
    }

    public ILocator DebuggingFeaturesLink { get; }
    public Task ClickDebuggingFeaturesAsync() => DebuggingFeaturesLink.ClickAsync();
}
