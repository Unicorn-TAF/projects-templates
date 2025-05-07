using Unicorn.UI.Web;
using Unicorn.UI.Web.Driver;
using Unicorn.UI.Web.PageObject;

namespace Company.WebModule
{
    /// <summary>
    /// Describes specific website implementation.<br/>
    /// The base website gives access to underlying <see cref="WebDriver"/> instance, provides with pages cache 
    /// mechanism (to avoid page creation each time) and eases pages navigation. 
    /// Some site specific actions and helpers could be placed here.
    /// <br/>
    /// The website should inherit <see cref="WebSite"/>
    /// </summary>
    public class TestWebsite : WebSite
    {
        /// <summary>
        /// Website creation based on existing explicitly created WebDriver instance.
        /// Should call base constructor.
        /// </summary>
        /// <param name="driver"><see cref="WebDriver"/> instance</param>
        public TestWebsite(WebDriver driver) : base(driver, "<site-url>") { }           // TODO: <--------- Specify website base URL

        /// <summary>
        /// Website creation based on retrieved type of browser (WebDriver in this case is created automatically).
        /// Should call base constructor.
        /// </summary>
        /// <param name="browser">type of browser</param>
        public TestWebsite(BrowserType browser) : base(browser, "<site-url>") { }       // TODO: <--------- Specify website base URL
    }
}
