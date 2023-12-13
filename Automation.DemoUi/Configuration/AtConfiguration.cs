using Automation.DemoUi.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUi.Configuration
{
    public class AtConfiguration : IAtConfiguration
    {

        IConfiguration _iconfiguration;
        public AtConfiguration()
        {
           IDefaultVariables idefaultVariables =SpecflowRunner._iserviceProvider.GetRequiredService<IDefaultVariables>();
           _iconfiguration=new ConfigurationBuilder().AddJsonFile(idefaultVariables.getAppplicationConfigjson).Build();
        }

        public string GetConfiguration(string key)
        {
          return _iconfiguration[key];
        }

    }
}
