using GenWikiTests.Pages;

namespace GenWikiTests.Tests
{
    [TestClass]
    public class MicrosoftDevToolsTest : BaseTest
    {
        [DataTestMethod]
        [TestCategory("LinkValidation")]
        [DescriptionAttribute("Task 2: Validate that all the “technology names” under this section are a text link")]
        [DataRow("TextLink")]
        [DataRow("TextLinkWithoutContainingPlainText")]
        [DataRow("DoesTextLinkHaveHrefAttribute")]
        public async Task ValidateMsDevToolsLinks(string examinationType)
        {
            // Via UI:  go to Microsoft development tools section
            var wikiPlaywrightMainPage = new PlaywrightWikiPage(_page);
            await wikiPlaywrightMainPage.NavigateAsync();
            await wikiPlaywrightMainPage.ClickExternalLinksAsync();
            ExternalLinksPage externalLinksPage = new ExternalLinksPage(_page);
            await externalLinksPage.ClickShowButtonAsync();
            // and validate that all the “technology names” under this section are a text link, 
            var technologiesLists = externalLinksPage.tableRowsLists;
            // if not please fail the test.
            await externalLinksPage.VerifyAllItemsAreLinks(technologiesLists, examinationType);
        }
    }
}