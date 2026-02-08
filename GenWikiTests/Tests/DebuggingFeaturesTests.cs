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
        var wikiPlaywrightMainPage = new PlaywrightWikiPage(page);
        await wikiPlaywrightMainPage.NavigateAsync();

        // var title = await page.TitleAsync();
        // Assert.IsTrue(title.Contains("Playwright (software)"), $"Unexpected title: {title}");
        await wikiPlaywrightMainPage.ClickDebuggingFeaturesAsync();
        DebuggingFeaturesSectionPage debuggingFeaturesSectionPage = new DebuggingFeaturesSectionPage(page);
        string sectionText = await debuggingFeaturesSectionPage.GetNormalizedTextAsync();
        Assert.IsFalse(string.IsNullOrEmpty(sectionText), "Section text should not be empty.");
    }
}