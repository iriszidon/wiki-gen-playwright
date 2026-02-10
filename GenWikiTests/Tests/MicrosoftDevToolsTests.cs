using GenWikiTests.Pages;
using GenWikiTests.Helpers;

namespace GenWikiTests.Tests
{
    [TestClass]
    public class MicrosoftDevToolsTest : BaseTest
    {
        [TestMethod]
        [TestCategory("LinkValidation")]
        [DescriptionAttribute("Task 2: Validate that all the “technology names” under this section are a text link")]
        public async Task SayHi()
        {
            // Via UI:  go to Microsoft development tools section (under “Debugging features”) 
            // and validate that all the “technology names” under this section are a text link, 
            // if not please fail the test.
            // Tip:  this is your decision if to do it as a one test case or multiple tests 
            var wikiPlaywrightMainPage = new PlaywrightWikiPage(_page);
            await wikiPlaywrightMainPage.NavigateAsync();
            await wikiPlaywrightMainPage.ClickExternalLinksAsync();
            ExternalLinksPage externalLinksPage = new ExternalLinksPage(_page);
            await externalLinksPage.ClickShowButtonAsync();
            Assert.IsFalse(false);
        }
    }
}