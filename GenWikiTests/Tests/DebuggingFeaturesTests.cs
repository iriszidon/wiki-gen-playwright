using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenWikiTests.Pages;

namespace GenWikiTests.Tests;


[TestClass]
public class ExampleTest : BaseTest
{
    [TestMethod]
    [TestCategory("Navigation")]
    [DescriptionAttribute("Count unique words using UI and API and compare results")]
    public async Task NavigateToWikiHomePageTest()
    {
        var page = await _browser.NewPageAsync();
        var wiki = new PlaywrightWikiPage(page);
        await wiki.NavigateAsync();

        var title = await page.TitleAsync();
        Assert.IsTrue(title.Contains("Playwright (software)"), $"Unexpected title: {title}");
    }
}