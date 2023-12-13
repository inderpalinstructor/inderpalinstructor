using Automation.DemoUi.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.Base;
using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUi.Pages
{
    public class LoginPage : TestBase, ILoginPage
    {
        IAtConfiguration _iatConfiguration;
        IDrivers _idriver;

        IAtBy byUserName => GetBy(LocatorType.Xpath, "//input[@id='user-name']");
        IAtWebElement UserName => _idriver.FindElement(byUserName);
        IAtBy byPassword => GetBy(LocatorType.Xpath, "//input[@id='password']");
        IAtWebElement Password => _idriver.FindElement(byPassword);
        IAtBy byLogin => GetBy(LocatorType.Id, "login-button");
        IAtWebElement Login => _idriver.FindElement(byLogin);

        public LoginPage(IObjectContainer iobjectContainer,IAtConfiguration iatConfiguration,IDrivers idrivers): base(iobjectContainer)
        {
            _iatConfiguration = iatConfiguration;
            _idriver = idrivers;
        }

        public void LoginWithValidCrendentials()
        {
           string url= _iatConfiguration.GetConfiguration("url");
            _idriver.NavigateTo(url);
            UserName.SendKeys("standard_user");
            Password.SendKeys("secret_sauce");
            Login.Click();           
        }
    }
}
