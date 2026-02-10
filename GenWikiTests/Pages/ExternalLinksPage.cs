using Microsoft.Playwright;
using GenWikiTests.Helpers;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace GenWikiTests.Pages;

public class ExternalLinksPage : BasePage
{
    public ExternalLinksPage(IPage page) : base(page)
    {
        this._page = page;
    }

    public ILocator showMsDevToolsLinkButton => _page.GetByRole(AriaRole.Button, new() { Name = "show" }).First;
    public ILocator msLinksTable => _page.Locator("//div[@aria-labelledby='Microsoft_development_tools6288']");
    // public IEnumerable<ILocator> tableRows => msLinksTable.Locator("tr").AllAsync().Result.Skip(1); // Skip header row
    public IEnumerable<ILocator> tableRowsLists => msLinksTable.Locator("//ul/li").AllAsync().Result.Skip(3);


    public async Task ClickShowButtonAsync()
    {
        await showMsDevToolsLinkButton.ClickAsync();
    }

    public async Task<bool> IsTextLink(ILocator listItem)
    {
        var link = listItem.Locator("a");
        return await link.CountAsync() > 0;
    }

    public async Task<bool> TextLinkWithoutContainingPlainText(ILocator listItem)
    {

        // Evaluate in the browser: iterate only direct childNodes of <div>
        return await listItem.EvaluateAsync<bool>(@"(el) => {
        for (const node of el.childNodes) {
            // TEXT_NODE === 3
            if (node.nodeType === Node.TEXT_NODE &&
                node.textContent &&
                node.textContent.trim().length > 0) {
                return true;
            }
        }
        return false;
    }");

    }

    public async Task<bool> DoesTextLinkHaveHrefAttribute(ILocator listItem)
    {
        IEnumerable<ILocator> links = listItem.Locator("a").AllAsync().Result;
        if (links.Count() == 0)
        {
            return false;
        }
        foreach (var link in links)
        {
            if (await link.GetAttributeAsync("href") != null)
            {
                return true;
            }
        }
        return false;
    }

    public async Task VerifyAllItemsAreLinks(IEnumerable<ILocator> technologiesLists, string linkType)
    {
        foreach (var list in technologiesLists)
        {
            bool isTheItemALink;
            string additionalInfo = "";
            switch (linkType)
            {
                case "TextLink":
                    isTheItemALink = await IsTextLink(list);
                    additionalInfo = "It is not a text link because it does not contain an <a> element.";
                    break;
                case "TextLinkWithoutContainingPlainText":
                    isTheItemALink = !await TextLinkWithoutContainingPlainText(list);
                    additionalInfo = "It is not a text link because it contains plain text that is not part of the link.";
                    break;
                case "DoesTextLinkHaveHrefAttribute":
                    isTheItemALink = await DoesTextLinkHaveHrefAttribute(list);
                    additionalInfo = "It is not a text link because the <a> element does not have an href attribute.";
                    break;
                default:
                    throw new ArgumentException($"Invalid link type: {linkType}");
            }
            string listText = await list.TextContentAsync();
            Console.WriteLine(listText);
            Assert.IsTrue(isTheItemALink, $"List item '{listText}' is not a text link. {additionalInfo}");
        }
    }
}