using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]

public class Tests : PageTest
{
   
	[Test]
    public async Task BoxCreationValid()
     {
        await Page.GotoAsync("http://localhost:4200/");

        await Page.Locator("ion-fab-button").GetByRole(AriaRole.Img).Nth(1).ClickAsync();

        await Page.Locator("#ion-overlay-1 label").Filter(new() { HasText = "insert a name for the box please" }).ClickAsync();

        await Page.Locator("#ion-input-14").FillAsync("Naming");

        await Page.Locator("#ion-overlay-1 label").Filter(new() { HasText = "please add a description" }).ClickAsync();

        await Page.Locator("#ion-input-15").FillAsync("Working Now");

        await Page.Locator("#ion-overlay-1 label").Filter(new() { HasText = "please insert the length of the box" }).ClickAsync();

        await Page.Locator("#ion-input-16").FillAsync("450");

        await Page.Locator("#ion-overlay-1 label").Filter(new() { HasText = "please insert the width of the box" }).ClickAsync();

        await Page.Locator("#ion-input-17").FillAsync("459");

        await Page.Locator("#ion-overlay-1 label").Filter(new() { HasText = "please insert the height of the box" }).ClickAsync();

        await Page.Locator("#ion-input-18").FillAsync("900");

        await Page.Locator("#ion-overlay-1 label").Filter(new() { HasText = "please add a price" }).ClickAsync();

        await Page.Locator("#ion-input-19").FillAsync("500");

        await Page.Locator("#ion-overlay-1").GetByRole(AriaRole.Button, new() { Name = "send" }).ClickAsync();

    }
	
	[Test]
		 public async Task BoxCreationInvalid()
  		  {
        await Page.GotoAsync("http://localhost:4200/");

        await Page.Locator("ion-fab-button").GetByRole(AriaRole.Img).Nth(1).ClickAsync();

        await Page.Locator("#ion-overlay-1 label").Filter(new() { HasText = "insert a name for the box please" }).ClickAsync();

        await Page.Locator("#ion-input-13").FillAsync("bad");

        await Page.Locator("#ion-input-14").ClickAsync();

        await Page.Locator("#ion-input-14").FillAsync("tester");

        await Page.Locator("#ion-input-15").ClickAsync();

        await Page.Locator("#ion-input-15").FillAsync("455");

        await Page.Locator("#ion-input-16").ClickAsync();

        await Page.Locator("#ion-input-16").FillAsync("4455");

        await Page.Locator("#ion-input-17").ClickAsync();

        await Page.Locator("#ion-input-17").FillAsync("555");

        await Page.Locator("#ion-input-18").ClickAsync();

        await Page.Locator("#ion-input-18").FillAsync("4555");

        await Page.Locator("#ion-overlay-1").GetByRole(AriaRole.Button, new() { Name = "send" }).ClickAsync();

        Assert.Fail("Box creation should have failed with an invalid input.");

    }
		
}

/*
 dotnet tool install --global Microsoft.Playwright.CLI
playwright install
*/