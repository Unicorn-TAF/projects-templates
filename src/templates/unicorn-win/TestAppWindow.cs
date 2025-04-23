using UIAutomationClient;
using Unicorn.UI.Core.PageObject;
using Unicorn.UI.Core.PageObject.By;
using Unicorn.UI.Win.Controls;
using Unicorn.UI.Win.Controls.Typified;

namespace Company.WinModule
{
    public class TestAppWindow : Window
    {
        public TestAppWindow() { }

        public TestAppWindow(IUIAutomationElement instance) : base(instance) { }

        [Name("element-name")]
        [ById("element-id")]
        public Button SomeButton { get; set; }

        [Name("other-element-name")]
        [ByName("element-name-property")]
        public WinControl ShowConfigButton { get; set; }
    }
}
