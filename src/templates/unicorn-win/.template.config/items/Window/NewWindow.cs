using UIAutomationClient;
using Unicorn.UI.Core.PageObject;
using Unicorn.UI.Core.PageObject.By;
using Unicorn.UI.Win.Controls.Typified;

namespace Company.WinModule
{
    public class NewWindow : Window
    {
        public NewWindow() { }

        public NewWindow(IUIAutomationElement instance) : base(instance) { }

        [Name("element-name")]
        [ById("element-id")]
        public Button SomeButton { get; set; }
    }
}
