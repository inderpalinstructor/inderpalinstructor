
using Automation.Framework.Core.WebUI.WebElements;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.Abstraction
{
    public interface IDrivers
    {
        IWebDriver GetWebDriver();
        void CloseBrowser();

        IAtWebElement FindElement(IAtBy iatBy);

        void NavigateTo(string url);

        string GetPageTitle();
        void GetNewTab();
        void CloseCurrentBrowser();
        void SwitchToWindowWithHandle(string handle);
        void SwitchToWindowWithTitle(string title);
        void SwitchToFrameWithName(string frameName);
        void Maximize();
        void ExecuteJavaScript(string script);
        void ScrollWithPixel();
        void ScrollByheight();
        void ScrollIntoView(IAtWebElement iatWebElement);

        string GetScreenShot();
        int FindElementsCount(IAtBy iatBy);
        bool IsElementVisible(IAtWebElement iatWebElement, int sec);
        void SwitchToParentFrame();




    }
}
