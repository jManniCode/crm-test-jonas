using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Server.GuiTests;

[TestClass]
public class CompanyFlowTest
{
    private IPlaywright _playwright = null!;
    private IBrowser _browser = null!;
    private IBrowserContext _context = null!;
    private IPage _page = null!;

    [TestInitialize]
    public async Task Setup()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 1000
        });
        _context = await _browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = null // Fullskärm
        });
        _page = await _context.NewPageAsync();
    }

    [TestCleanup]
    public async Task Cleanup()
    {
        await _context.CloseAsync();
        await _browser.CloseAsync();
        _playwright.Dispose();
    }

    [TestMethod]
    public async Task SuperAdmin_CanBlock_And_Reactivate_Company()
    {
        await _page.GotoAsync("http://localhost:5000/");


await _page.GotoAsync("http://localhost:5000/");
await _page.GetByRole(AriaRole.Textbox, new() { Name = "Email.." }).ClickAsync();
await _page.GetByRole(AriaRole.Textbox, new() { Name = "Email.." }).FillAsync("super_gris@mail.com");
await _page.GetByRole(AriaRole.Textbox, new() { Name = "Password.." }).ClickAsync();
await _page.GetByRole(AriaRole.Textbox, new() { Name = "Password.." }).FillAsync("kung");
await _page.GetByRole(AriaRole.Button, new() { Name = "login!" }).ClickAsync();
await _page.GetByRole(AriaRole.Button, new() { Name = "Companies" }).ClickAsync();
await _page.GetByRole(AriaRole.Button, new() { Name = "block" }).Nth(3).ClickAsync();
await _page.GetByRole(AriaRole.Button, new() { Name = "Show Inactive Companies" }).ClickAsync();
await _page.GetByRole(AriaRole.Button, new() { Name = "Activate" }).ClickAsync();
await _page.GetByRole(AriaRole.Button, new() { Name = "⬅️ Back" }).ClickAsync();
await _page.GetByRole(AriaRole.Button, new() { Name = "Sign Out" }).ClickAsync();


        
        await _page.WaitForSelectorAsync("input[name=email]");
        Assert.IsTrue(await _page.IsVisibleAsync("input[name=email]"));
    }

[TestMethod]
public async Task Admin_CanBlockAndReactivateProduct()
{
    await _page.GotoAsync("http://localhost:5000/");

    await _page.GetByRole(AriaRole.Textbox, new() { Name = "Email.." }).ClickAsync();
    await _page.GetByRole(AriaRole.Textbox, new() { Name = "Email.." }).FillAsync("grune@grymt.se");
    await _page.GetByRole(AriaRole.Textbox, new() { Name = "Email.." }).PressAsync("Tab");
    await _page.GetByRole(AriaRole.Textbox, new() { Name = "Password.." }).FillAsync("hejhej");
    await _page.GetByRole(AriaRole.Button, new() { Name = "login!" }).ClickAsync();

    await _page.GetByRole(AriaRole.Button, new() { Name = "Products" }).ClickAsync();

    await _page.GetByRole(AriaRole.Listitem)
        .Filter(new() { HasText = "Name:Mud BathPrice:50Category" })
        .GetByRole(AriaRole.Button)
        .Nth(1)
        .ClickAsync();

    await _page.GetByRole(AriaRole.Button, new() { Name = "Show Inactive Products" }).ClickAsync();
    await _page.GetByRole(AriaRole.Button, new() { Name = "Activate" }).ClickAsync();
    await _page.GetByRole(AriaRole.Button, new() { Name = "⬅️ Back" }).ClickAsync();
    await _page.GetByRole(AriaRole.Button, new() { Name = "Sign Out" }).ClickAsync();

    await _page.WaitForSelectorAsync("input[name=email]");
    Assert.IsTrue(await _page.IsVisibleAsync("input[name=email]"));
}

}

