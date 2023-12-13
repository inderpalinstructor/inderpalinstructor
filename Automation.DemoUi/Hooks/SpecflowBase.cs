using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.Reports;
using Automation.Framework.Core.WebUI.Runner;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUi.Hooks
{
    [Binding]
    public class SpecflowBase
    {
        IGlobalProperties iglobalProperties;
        IChromeWebDriver _ichromeWebDriver;
        IFirefoxWebDriver _ifirefoxWebDriver;
        IDrivers _idrivers;
        ScenarioContext _scenarioContext;
        public SpecflowBase(IChromeWebDriver _chromeWebDriver,IFirefoxWebDriver ifirefoxWebDriver,IDrivers idrivers)
        {
            _ichromeWebDriver= _chromeWebDriver;
            _ifirefoxWebDriver= ifirefoxWebDriver;  
            _idrivers= idrivers;
        }

        [BeforeScenario(Order =2)]
        public void BeforeScenario(IObjectContainer iobjectContainer,ScenarioContext scenarioContext,FeatureContext fs)
        {
           _idrivers=iobjectContainer.Resolve<IDrivers>();
            _scenarioContext = scenarioContext;
          IExtentReport extentReport=(IExtentReport)  fs["iextentreport"];
            extentReport.CreateScenario(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterSteps(ScenarioContext sc,FeatureContext fs)
        {
            IExtentReport extentReport = (IExtentReport)fs["iextentreport"];
            if (sc.TestError != null)
            {
                string base64 = null;
                base64=_idrivers.GetScreenShot();
                extentReport.Fail(sc.StepContext.StepInfo.Text,base64);
            }
            else
            {
                IGlobalProperties iglobalProperties = SpecflowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
                string base64=null;
                if (iglobalProperties.stepscreenshot)
                {
                    base64 = _idrivers.GetScreenShot();
                }
                extentReport.Pass(sc.StepContext.StepInfo.Text,base64);
            }
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext sc,FeatureContext fs)
        {
            IExtentFeatureReport extentFeatureReport = SpecflowRunner._iserviceProvider.GetRequiredService<IExtentFeatureReport>();
            extentFeatureReport.FlushExtent();
            Thread.Sleep(3000);
            _idrivers.CloseBrowser();          
        }       

    }
}
