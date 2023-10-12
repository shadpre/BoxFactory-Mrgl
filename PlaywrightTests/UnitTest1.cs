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

        await Page.GetByTestId("boxName").Locator("input").Nth(1).FillAsync("Textbox");

        await Page.GetByTestId("boxingtester").Locator("input").Nth(1).FillAsync("En Box");

		await Page.GetByTestId("boxLength").Locator("input").Nth(1).FillAsync("350");

		await Page.GetByTestId("boxHeight").Locator("input").Nth(1).FillAsync("350");

		await Page.GetByTestId("boxWidth").Locator("input").Nth(1).FillAsync("350");

		await Page.GetByTestId("boxPrice").Locator("input").Nth(1).FillAsync("350");

		await Page.Locator("#ion-overlay-1").GetByRole(AriaRole.Button, new() { Name = "send" }).ClickAsync();

 	 }
*/

[Test]
   public async Task pwDelete()
    {
        await Page.GotoAsync("http://localhost:4200/");

        await Page.GetByTestId("boxDeleter").Nth(1).ClickAsync();

	}



    [Test]
    public async Task addToStorage()
    {
        await Page.GotoAsync("http://localhost:4200/");

        await Page.Locator("#ion-input-6").ClickAsync();

        await Page.Locator("#ion-input-6").FillAsync("5");

        await Page.Locator("ion-card").Filter(new() { HasText = "string, a boxLength: 2000 mm - Width: 3000 mm - Height: 2000 mmPrice: 25 kr.In s" }).GetByRole(AriaRole.Button).First.ClickAsync();

    }

}
	
/*	[Test]
		 public async Task BoxCreationInvalid()
  		  {
           await Page.GotoAsync("http://localhost:4200/");

        await Page.Locator("ion-fab-button").GetByRole(AriaRole.Img).Nth(1).ClickAsync();

        await Page.GetByTestId("boxName").Locator("input").Nth(1).FillAsync("Textbox");

        await Page.GetByTestId("boxingtester").Locator("input").Nth(1).FillAsync("En Box");

		await Page.GetByTestId("boxLength").Locator("input").Nth(1).FillAsync("350");

		await Page.GetByTestId("boxHeight").Locator("input").Nth(1).FillAsync("350");

		await Page.GetByTestId("boxWidth").Locator("input").Nth(1).FillAsync("350");

		await Page.GetByTestId("boxPrice").Locator("input").Nth(1).FillAsync("350");

		await Page.Locator("#ion-overlay-1").GetByRole(AriaRole.Button, new() { Name = "send" }).ClickAsync();

		Assert.False;

    }
		
}

/*
 dotnet tool install --global Microsoft.Playwright.CLI
playwright install
*/