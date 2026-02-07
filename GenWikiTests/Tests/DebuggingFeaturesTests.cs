using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenWikiTests.Tests;


[TestClass]
public class ExampleTest : BaseTest
{
    [TestMethod]
    public async Task SampleTest()
    {
        var page = await _browser.NewPageAsync();
        await page.GotoAsync("https://playwright.dev");

        StringAssert.Contains(await page.TitleAsync(), "Playwright");
    }
}