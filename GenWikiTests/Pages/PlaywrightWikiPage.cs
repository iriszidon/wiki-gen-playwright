using Microsoft.Playwright;

namespace GenWikiTests.Pages;

public class PlaywrightWikiPage : BasePage
{
    public ILocator ExternalLinksSection => _page.Locator("#toc-External_links");
    public ILocator DebuggingFeaturesLink => _page.Locator("a:has-text(\"Debugging features\")");
    public ILocator ColorModeButton => _page.Locator("#skin-client-pref-skin-theme-value-night");
    public ILocator HtmlElement => _page.Locator("html");
    public PlaywrightWikiPage(IPage page) : base(page)
    {
        this._page = page;
    }
    public Task ClickDebuggingFeaturesAsync() => DebuggingFeaturesLink.ClickAsync();
    public Task ClickExternalLinksAsync() => ExternalLinksSection.ClickAsync();
    public Task ClickColorModeButtonAsync() => ColorModeButton.ClickAsync();

    public async Task<string> GetHtmlElementClassAsync()
    {
        Console.WriteLine("Getting 'class' attribute of <html> element.");
        return await HtmlElement.GetAttributeAsync("class") ?? string.Empty;
    }

    public async Task<bool> IsDarkModeEnabledAsync()
    {
        string htmlClass = await GetHtmlElementClassAsync();
        Console.WriteLine($"Check if dark mode is enabled.");
        return htmlClass.Contains("skin-theme-clientpref-night");
    }
}
