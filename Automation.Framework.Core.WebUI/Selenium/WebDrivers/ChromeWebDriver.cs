using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.Runner;
using AventStack.ExtentReports.Utils;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Framework.Core.WebUI.Selenium.WebDrivers
{
    public class ChromeWebDriver : IChromeWebDriver
    {
        IGlobalProperties _iglobalProperties;
        public ChromeWebDriver()
        {
            _iglobalProperties = SpecflowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
        }

        public IWebDriver GetChromeWebDriver()
        {
            IWebDriver iwebdriver;
            if (string.IsNullOrEmpty(_iglobalProperties.gridhuburl))
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                iwebdriver = new ChromeDriver(GetOptions());
                iwebdriver.Manage().Window.Maximize();
            }
            else
            {
                iwebdriver = new RemoteWebDriver(new Uri(_iglobalProperties.gridhuburl), GetOptions());
            }           

            return iwebdriver;
        }

        public ChromeOptions GetOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;

            options.AddExcludedArgument("enable-automation");
            options.AddArgument("disable-extensions");
            options.AddArgument("disable-infobars");
            options.AddArgument("disable-notifications");
            options.AddArgument("disable-web-security");
            options.AddArgument("dns-prefetch-disable");
            options.AddArgument("disable-browser-side-navigation");
            options.AddArgument("disable-gpu");
            options.AddArgument("always-authorize-plugins");
            options.AddArgument("load-extension=src/main/resources/chrome_load_stopper");
            options.AddUserProfilePreference("download.default_directory", _iglobalProperties.datasetlocation);
            return options;
        }
    }
}
