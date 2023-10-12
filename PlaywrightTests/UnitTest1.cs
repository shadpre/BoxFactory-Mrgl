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
  
	[Test, Order(1)]
    public async Task pwCreateBox()
     {
        await Page.GotoAsync("http://localhost:4200/");

        await Page.Locator("ion-fab-button").GetByRole(AriaRole.Img).Nth(1).ClickAsync();

        await Page.GetByTestId("boxName").Locator("input").Nth(1).FillAsync("Test");

        await Page.GetByTestId("boxingtester").Locator("input").Nth(1).FillAsync("Test");

		await Page.GetByTestId("boxLength").Locator("input").Nth(1).FillAsync("220");

		await Page.GetByTestId("boxHeight").Locator("input").Nth(1).FillAsync("222");

		await Page.GetByTestId("boxWidth").Locator("input").Nth(1).FillAsync("220");

		await Page.GetByTestId("boxPrice").Locator("input").Nth(1).FillAsync("220");

		await Page.Locator("#ion-overlay-1").GetByRole(AriaRole.Button, new() { Name = "send" }).ClickAsync();
		
		await Task.Delay(10000);
		
		await Page.ReloadAsync();
		
		var targetCardText = "TestLength: 220 mm - Width: 220 mm - Height: 222 mmPrice: 220 kr.In storage: Add";
        
		var cardSelector = $"ion-card:has-text(\"{targetCardText}\")";

		await Page.WaitForSelectorAsync(cardSelector);


     }
	
	[Test, Order(2)]
    public async Task pwUpdateBox()
    {
        await Page.GotoAsync("http://localhost:4200/");

        await Page.Locator("ion-card").Filter(new() { HasText = "TestLength: 220 mm - Width: 220 mm - Height: 222 mmPrice: 220 kr.In storage: Add" }).Locator("svg").Nth(1).ClickAsync();
 		
		await Page.GetByTestId("updateName").Locator("input").Nth(1).FillAsync("Test");

		await Page.GetByTestId("updateHeight").Locator("input").Nth(1).FillAsync("2222");

        await Page.Locator("#ion-overlay-1").GetByRole(AriaRole.Button, new() { Name = "Update" }).ClickAsync();

		await Page.ReloadAsync();
    }



 	[Test, Order(3)]
    public async Task pwDeleteBox()
    {
        await Page.GotoAsync("http://localhost:4200/");

        await Page.Locator("ion-card").Filter(new() { HasText = "TestLength: 220 mm - Width: 220 mm - Height: 2222 mmPrice: 220 kr.In storage: Add" }).GetByTestId("boxDeleter").GetByRole(AriaRole.Img).ClickAsync();

    }
    

 /*   [Test]
    public async Task addToStorage()
    {
        await Page.GotoAsync("http://localhost:4200/");

        await Page.Locator("#ion-input-15").ClickAsync();

        await Page.Locator("#ion-input-15").FillAsync("5");

        await Page.Locator("ion-card").Filter(new() { HasText = "EN BOX boxLength: 350 mm - Width: 350 mm - Height: 350 mmPrice: 350 kr.In s" }).GetByRole(AriaRole.Button).First.ClickAsync();

    }
*/

}
	


/*
 dotnet tool install --global Microsoft.Playwright.CLI
playwright install
*/