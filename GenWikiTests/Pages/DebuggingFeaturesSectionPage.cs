using Microsoft.Playwright;
using System.Threading.Tasks;

namespace GenWikiTests.Pages;

public class DebuggingFeaturesSectionPage : BasePage
{
    public DebuggingFeaturesSectionPage(IPage page) : base(page)
    {
        this._page = page;
    }

    public ILocator DebuggingFeaturesSectionTitle => _page.Locator("#Debugging_features");
    public ILocator DebuggingFeaturesSectionParent => _page.Locator("#mw-content-text");
    // public ILocator DebuggingFeaturesSectionSubTitle =>
    // DebuggingFeaturesSectionParent.Locator("//div[2]/p[13]");

    public ILocator DebuggingFeaturesSectionSubTitle =>
        DebuggingFeaturesSectionParent.Locator("//div//p[contains(text(), 'debugging capabilities')]");
    public ILocator DebuggingFeaturesSectionContent =>
    DebuggingFeaturesSectionParent.Locator("//div[2]/ul[2]");

    public async Task<string> GetNormalizedTextAsync()
    {
        string sectionText = await DebuggingFeaturesSectionTitle.TextContentAsync();
        string subTitleText = await DebuggingFeaturesSectionSubTitle.TextContentAsync();
        string contentText = await DebuggingFeaturesSectionContent.TextContentAsync();

        Console.WriteLine("\n ;-)");
        Console.WriteLine(sectionText);
        Console.WriteLine(subTitleText);
        Console.WriteLine(contentText);

        return sectionText + subTitleText + contentText;
    }
}
