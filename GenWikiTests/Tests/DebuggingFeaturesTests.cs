using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenWikiTests.Pages;
using GenWikiTests.Helpers;
namespace GenWikiTests.Tests;


[TestClass]
public class ExampleTest : BaseTest
{
    [TestMethod]
    [TestCategory("WordCount")]
    [DescriptionAttribute("Count unique words using UI and API and compare results")]
    public async Task GetTextFromUITest()
    {
        var page = await _browser.NewPageAsync();
        var wikiPlaywrightMainPage = new PlaywrightWikiPage(page);
        await wikiPlaywrightMainPage.NavigateAsync();

        // var title = await page.TitleAsync();
        // Assert.IsTrue(title.Contains("Playwright (software)"), $"Unexpected title: {title}");
        await wikiPlaywrightMainPage.ClickDebuggingFeaturesAsync();
        DebuggingFeaturesSectionPage debuggingFeaturesSectionPage = new DebuggingFeaturesSectionPage(page);
        string sectionText = await debuggingFeaturesSectionPage.GetNormalizedTextAsync();
        Console.WriteLine($"Normalized section text: \n{sectionText}");
        Assert.IsFalse(string.IsNullOrEmpty(sectionText), "Section text should not be empty.");
    }

    [TestMethod]
    [TestCategory("Sample")]
    public async Task GetTextFromApiTest()
    {
        string sectionText = await ApiUtils.GetDebuggingFeaturesTextAsync("json", "Playwright_(software)", 5);
        string plainSectionText = JsonToHtmlConverterUtil.ExtractPlainTextFromParseJson(sectionText);
        string normalizedSectionText = TextUtils.NormalizeTextWithCharsOnly(plainSectionText);

        Console.WriteLine($"Plain text from API: \n{plainSectionText}");
        Console.WriteLine($"Characters-only text from API: \n{normalizedSectionText}");

        Assert.IsFalse(string.IsNullOrEmpty(plainSectionText), "Section text from API should not be empty.");
    }
}