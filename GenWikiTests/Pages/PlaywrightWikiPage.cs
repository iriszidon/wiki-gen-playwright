using Microsoft.Playwright;

namespace GenWikiTests.Pages;

public class PlaywrightWikiPage : BasePage
{

    public ILocator ExternalLinksSection => _page.Locator("#toc-External_links");
    public ILocator DebuggingFeaturesLink { get; }
    public ILocator ColorModeButton => _page.Locator("#skin-client-pref-skin-theme-value-night");
    public ILocator HtmlElement => _page.Locator("html");
    public Task ClickDebuggingFeaturesAsync() => DebuggingFeaturesLink.ClickAsync();
    public Task ClickExternalLinksAsync() => ExternalLinksSection.ClickAsync();

    public Task ClickColorModeButtonAsync() => ColorModeButton.ClickAsync();
    public PlaywrightWikiPage(IPage page) : base(page)
    {
        DebuggingFeaturesLink = page.Locator("a:has-text(\"Debugging features\")");
    }

    public async Task<string> GetHtmlElementClassAsync()
    {
        return await HtmlElement.GetAttributeAsync("class") ?? string.Empty;
    }

    public async Task<bool> IsDarkModeEnabledAsync()
    {
        string htmlClass = await GetHtmlElementClassAsync();
        return htmlClass.Contains("skin-theme-clientpref-night");
    }
}
