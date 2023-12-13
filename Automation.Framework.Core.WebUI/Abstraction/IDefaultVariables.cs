using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstraction
{
    public interface IDefaultVariables
    {

        string getLog { get; }

        string getframeworkSettingjson { get; }
        string dataSetLocation { get; }
        string gridhuburl { get; }

        string getAppplicationConfigjson { get; }

        string getExtentReport { get; }
    }
}
