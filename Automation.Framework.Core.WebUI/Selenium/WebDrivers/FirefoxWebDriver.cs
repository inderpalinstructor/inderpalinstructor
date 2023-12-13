using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.Runner;
using AventStack.ExtentReports.Utils;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Framework.Core.WebUI.Selenium.WebDrivers
{
    public class FirefoxWebDriver : IFirefoxWebDriver
    {
        IGlobalProperties _iglobalProperties;
        public FirefoxWebDriver()
        {
            _iglobalProperties = SpecflowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
        }

        public IWebDriver GetFirefoxDriver()
        {
            IWebDriver webDriver;
            if (string.IsNullOrEmpty(_iglobalProperties.gridhuburl))
            {
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                 webDriver = new FirefoxDriver(GetOptions());
                webDriver.Manage().Window.Maximize();
            }
            else
            {
                webDriver = new RemoteWebDriver(new Uri(_iglobalProperties.gridhuburl), GetOptions());
            }
            return webDriver;
        }

        public FirefoxOptions GetOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            options.SetPreference("network.http.phishy-userpass-length", 255);
            options.SetPreference("network.automatic-ntlm-auth.allow-non-fqdn", true);
            options.SetPreference("network.negotiate-auth.allow-non-fqdn", true);
            options.SetPreference("browser.tabs.remote.autostart", false);
            options.SetPreference("browser.tabs.remote.autostart.1", false);
            options.SetPreference("browser.tabs.remote.autostart.2", false);
            options.SetPreference("browser.tabs.remote.force-enable", "false");
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.helperApps.alwaysAsk.force", false);
            options.SetPreference("browser.download.manager.showWhenStarting", false);
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            options.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            options.SetPreference("browser.download.manager.focusWhenStarting", false);
            options.SetPreference("browser.download.manager.useWindow", false);
            options.SetPreference("browser.download.manager.showAlertOnComplete", false);
            options.SetPreference("browser.download.manager.closeWhenDone", true);
            options.SetPreference("browser.download.dir", _iglobalProperties.datasetlocation);
            return options;
        }
    }
}
