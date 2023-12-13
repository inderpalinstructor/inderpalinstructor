using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstraction
{
    public interface IGlobalProperties
    {
        public string browsertype { get; }
        public string gridhuburl { get;}
        public bool stepscreenshot { get; }
        public string extentreportportalurl { get; }
        public bool extentreporttoportal { get; }
        public string loglevel { get; }
        public string datasetlocation { get; }
        public string downloadedlocation { get; }
        void Configuration();
    }
}
