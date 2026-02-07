using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenWikiTests.Tests;


[TestClass]
public class ExampleTest
{
    private IBrowser _browser;
    private IPlaywright _playwright;

    [TestInitialize]
    public async Task Setup()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 750 });
    }

    [TestMethod]
    public async Task HomepageShouldHaveTitle()
    {
        var page = await _browser.NewPageAsync();
        await page.GotoAsync("https://playwright.dev");

        StringAssert.Contains(await page.TitleAsync(), "Playwright");
    }

    [TestCleanup]
    public async Task Cleanup()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}