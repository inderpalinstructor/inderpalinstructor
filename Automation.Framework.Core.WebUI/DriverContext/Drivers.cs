using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.CustomException;
using Automation.Framework.Core.WebUI.Reports;
using Automation.Framework.Core.WebUI.Runner;
using Automation.Framework.Core.WebUI.WebElements;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.DriverContext
{
    [Binding]
    public class Drivers : IDrivers
    {
        IGlobalProperties _iglobalProperties;
        IChromeWebDriver _ichromeWebDriver;
        IFirefoxWebDriver _ifirefoxWebDriver;
        IObjectContainer _iobjectContainer;
        IWebDriver _iwebDriver;
        ScenarioContext _scenarioContext;
        ILogging _ilogging;
        public Drivers(IChromeWebDriver ichromeWebDriver,IFirefoxWebDriver ifirefoxWebDriver,
            IObjectContainer iobjectContainer,ScenarioContext scenarioContext)
        {
            _ichromeWebDriver = ichromeWebDriver;
            _ifirefoxWebDriver = ifirefoxWebDriver;
            _iobjectContainer = iobjectContainer;
            _scenarioContext = scenarioContext;
            _ilogging =SpecflowRunner._iserviceProvider.GetRequiredService<ILogging>();
        }
        public IWebDriver GetWebDriver()
        {
            if (_iwebDriver == null)
            {
                GetNewWebDriver();
            }            
            return _iwebDriver;
        }
        public IAtWebElement FindElement(IAtBy iatBy)
        {
          IAtWebElement iatWebElement=  _iobjectContainer.Resolve<IAtWebElement>();
          iatWebElement.Set(GetWebDriver(), iatBy);
            return iatWebElement; 
        }        
        public int FindElementsCount(IAtBy iatBy)
        {
           return GetWebDriver().FindElements(iatBy.By).Count;
        }     
        
       
        public bool IsElementVisible(IAtWebElement iatWebElement,int sec)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_iwebDriver, TimeSpan.FromSeconds(sec));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException)
                    , typeof(ElementNotVisibleException), typeof(ElementNotInteractableException));
               IWebElement webElement=  wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(iatWebElement.GetBy().By));
                return webElement.Displayed;
            }
            catch (Exception e)
            {
                _ilogging.Error("Element is not visible " + e.Message);
                throw new AutomationException("Element is not visible. " + e.Message);
            }
        }

        public void GetNewWebDriver()
        {
            _iglobalProperties = SpecflowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
            switch (_iglobalProperties.browsertype.ToLower())
            {
                case "chrome":
                    _iwebDriver = _ichromeWebDriver.GetChromeWebDriver();
                    break;
                case "firefox":
                    _iwebDriver = _ifirefoxWebDriver.GetFirefoxDriver();
                    break;
                default:
                    _iwebDriver = _ichromeWebDriver.GetChromeWebDriver();
                    break;
            }
            _iwebDriver.Manage().Window.Maximize();
        }

        public void CloseBrowser()
        {
            _iwebDriver.Quit();
        }      

        public void NavigateTo(string url)
        {
            GetWebDriver().Navigate().GoToUrl(url);
        }
        
        public string GetPageTitle()
        {
           return GetWebDriver().Title;
        }

        public void GetNewTab()
        {

            GetWebDriver().SwitchTo().NewWindow(WindowType.Tab);
        }

        public void CloseCurrentBrowser()
        {
            GetWebDriver().Close();
        }

        public void SwitchToWindowWithHandle(string handle)
        {
            GetWebDriver().SwitchTo().Window(handle);
        }

        public void SwitchToWindowWithTitle(string title)
        {
          IList<string> windowhandles= GetWebDriver().WindowHandles;

            foreach(string handle in windowhandles)
            {
                if (GetWebDriver().SwitchTo().Window(handle).Title.Contains(title))
                {
                    break;
                }
            }
        }


        public void SwitchToFrameWithName(string frameName)
        {
            GetWebDriver().SwitchTo().Frame(frameName);
        }

        public void Maximize()
        {
            GetWebDriver().Manage().Window.Maximize();
        }

        public void ExecuteJavaScript(string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript(script);
        }

        public void ScrollWithPixel()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript("window.scrollBy(0,500)");
        }

        public void ScrollByheight()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
        }

        public void ScrollIntoView(IAtWebElement iatWebElement)
        {
           IWebElement iwebElement= iatWebElement.GetElement();

            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript("agruments[0].scrollIntoView", iwebElement);
        }


        public string GetScreenShot()
        {
           return ((ITakesScreenshot)GetWebDriver()).GetScreenshot().AsBase64EncodedString;
        }

        public void SwitchToParentFrame()
        {
            _iwebDriver.SwitchTo().ParentFrame();
        }


    }
}
