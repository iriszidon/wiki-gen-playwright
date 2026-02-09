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

        await wikiPlaywrightMainPage.ClickDebuggingFeaturesAsync();
        DebuggingFeaturesSectionPage debuggingFeaturesSectionPage = new DebuggingFeaturesSectionPage(page);
        string sectionText = await debuggingFeaturesSectionPage.GetNormalizedTextAsync();
        Console.WriteLine($"Normalized section text: \n{sectionText}");
        Assert.IsFalse(string.IsNullOrEmpty(sectionText), "Section text should not be empty.");
    }


    [TestMethod]
    [TestCategory("Wikitext")]
    public async Task GetWikiTextFromApiTest()
    {
        string sectionText = await ApiUtils.GetDebuggingFeaturesWikiTextAsync("json", "Playwright_(software)", 5);
        string sectionTextWithoutWikiRef = TextUtils.RemoveWikiReferenceToolTip(sectionText, "ref");
        string normalizedSectionText = TextUtils.NormalizeTextWithCharsOnly(sectionTextWithoutWikiRef);
        Console.WriteLine($"Original wikitext from API: \n{sectionText}");
        Console.WriteLine($"Normalized wikitext from API: \n{normalizedSectionText}");
        Assert.IsFalse(string.IsNullOrEmpty(normalizedSectionText), "Section text from API should not be empty.");
    }
}