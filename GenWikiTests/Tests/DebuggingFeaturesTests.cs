using GenWikiTests.Pages;
using GenWikiTests.Helpers;

namespace GenWikiTests.Tests
{
    [TestClass]
    public class ExampleTest : BaseTest
    {
        [TestMethod]
        [TestCategory("WordCount")]
        [DescriptionAttribute("Count unique words using UI and API and compare results")]
        public async Task GetTextFromUITest()
        {
            var wikiPlaywrightMainPage = new PlaywrightWikiPage(_page);
            await wikiPlaywrightMainPage.NavigateAsync();
            await wikiPlaywrightMainPage.ClickDebuggingFeaturesAsync();
            DebuggingFeaturesSectionPage debuggingFeaturesSectionPage = new DebuggingFeaturesSectionPage(_page);
            string uiSectionText = await debuggingFeaturesSectionPage.GetNormalizedTextAsync();
            Console.WriteLine(TextUtils.CountUniqueWords(uiSectionText));
            // Get the text using Wki Parse API 
            int sectiobnIndex = 5; // Assuming the "Debugging features" section is the 5th section (index starts from 0)
            string apiSectionText = await ApiUtils.GetDebuggingFeaturesWikiTextAsync("json", "Playwright_(software)", sectiobnIndex);
            string sectionTextWithoutWikiRef = TextUtils.RemoveWikiReferenceToolTip(apiSectionText, "ref");
            string normalizedSectionText = TextUtils.NormalizeTextWithCharsOnly(sectionTextWithoutWikiRef);
            // Compare the results
            HashSet<string> uiUniqueWordCount = TextUtils.CountUniqueWords(uiSectionText);
            HashSet<string> apiUniqueWordCount = TextUtils.CountUniqueWords(normalizedSectionText);
            Assert.AreEqual(uiUniqueWordCount.Count, apiUniqueWordCount.Count, "Unique word count should match between UI and API results.");
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


        [TestMethod]
        public void CountUniqueWords_Test()
        {
            string input = "Hello world Hello everyone Welcome to the world of testing".ToLower();
            HashSet<string> uniqueWordCount = TextUtils.CountUniqueWords(input);
            Console.WriteLine($"Unique word count: {uniqueWordCount.Count}");
            Assert.AreEqual(8, uniqueWordCount.Count, "Unique word count should be 8.");
        }
    }
}