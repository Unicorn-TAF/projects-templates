using Unicorn.UI.Core.Driver;
using Unicorn.UI.Core.PageObject;
using Unicorn.UI.Web.Controls;
using Unicorn.UI.Web.Driver;
using Unicorn.UI.Web.PageObject;
using Unicorn.UI.Web.PageObject.Attributes;

namespace Company.WebModule
{
    [PageInfo("<page-relative-url>", "<page-title>")]
    public class NewWebPage : WebPage
    {
        public NewWebPage(WebDriver driver) : base(driver) { }

        [Name("element-name")]
        [Find(Using.WebXpath, "//some-xpath")]
        public WebControl WebElement { get; set; }
    }
}
