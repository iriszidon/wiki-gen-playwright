using GenWikiTests.Pages;

namespace GenWikiTests.Tests
{
    [TestClass]
    public class ColorModeTest : BaseTest
    {
        [DataTestMethod]
        [TestCategory("DarkModeValidation")]
        [DescriptionAttribute("Task 3: Validate that all the “technology names” under this section are a text link")]
        public async Task SwitchToDarkMode()
        {
            var wikiPlaywrightMainPage = new PlaywrightWikiPage(_page);
            await wikiPlaywrightMainPage.NavigateAsync();
            await wikiPlaywrightMainPage.ClickExternalLinksAsync();
            //Change the color to “Dark” 
            await wikiPlaywrightMainPage.ClickColorModeButtonAsync();
            //Validate that the color actually changed 
            bool isDarkModeEnabled = await wikiPlaywrightMainPage.IsDarkModeEnabledAsync();
            Assert.IsTrue(isDarkModeEnabled, "Color mode should be switched to Dark mode.");
        }
    }
}