using Unicorn.UI.Core.Driver;
using Unicorn.UI.Core.PageObject;
using Unicorn.UI.Core.PageObject.By;
using Unicorn.UI.Web.Controls;
using Unicorn.UI.Web.Controls.Typified;
using Unicorn.UI.Web.Driver;
using Unicorn.UI.Web.PageObject;
using Unicorn.UI.Web.PageObject.Attributes;

namespace Company.WebModule
{
    [PageInfo("<page-relative-url>", "<page-title>")]   // TODO: <--------- Specify page relative URL and page title
    public class TestPage : WebPage
    {
        [Name("element-name")]
        [ById("LOCATOR")]                               // TODO: <--------- Specify locator
        private readonly TextInput _someInput;

        public TestPage(WebDriver driver) : base(driver) { }

        [Name("other-element-name")]
        [Find(Using.WebXpath, "LOCATOR")]               // TODO: <--------- Specify locator
        public WebControl WebElement { get; set; }
    }
}
