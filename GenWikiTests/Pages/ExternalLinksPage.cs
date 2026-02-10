using Microsoft.Playwright;
using GenWikiTests.Helpers;

namespace GenWikiTests.Pages;

public class ExternalLinksPage : BasePage
{
    public ExternalLinksPage(IPage page) : base(page)
    {
        this._page = page;
    }

    public ILocator showMsDevToolsLinkButton => _page.GetByRole(AriaRole.Button, new() { Name = "show" }).First;


    public async Task ClickShowButtonAsync()
    {
        await showMsDevToolsLinkButton.ClickAsync();
    }
}