using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GenWikiTests.Tests;



[TestClass]
public class BaseTest
{
    protected IBrowser _browser;
    protected IPlaywright _playwright;
    protected IPage _page;

    [TestInitialize]
    public async Task Setup()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 750 });
        _page = await _browser.NewPageAsync();
    }

    [TestCleanup]
    public async Task Cleanup()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}