using Microsoft.Playwright;

namespace GenWikiTests.Pages;

public class PlaywrightWikiPage : BasePage
{

    public ILocator ExternalLinksSection => _page.Locator("#toc-External_links");
    public PlaywrightWikiPage(IPage page) : base(page)
    {
        DebuggingFeaturesLink = page.Locator("a:has-text(\"Debugging features\")");
    }

    public ILocator DebuggingFeaturesLink { get; }
    public Task ClickDebuggingFeaturesAsync() => DebuggingFeaturesLink.ClickAsync();
    public Task ClickExternalLinksAsync() => ExternalLinksSection.ClickAsync();

}
