using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.DIContainer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.Runner
{
    [Binding]
    public class SpecflowRunner
    {

      public static IServiceProvider _iserviceProvider;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
           _iserviceProvider= CoreContainerConfig.ConfigureSevices();
            _iserviceProvider.GetRequiredService<IGlobalProperties>();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext fs)
        {
           IExtentReport iextentReport =_iserviceProvider.GetRequiredService<IExtentReport>();
           iextentReport.CreateFeature(fs.FeatureInfo.Title);
            fs["iextentreport"]=iextentReport;
        }
    }
}
