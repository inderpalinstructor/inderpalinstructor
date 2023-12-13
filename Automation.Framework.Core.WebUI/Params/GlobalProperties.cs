using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.CustomException;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;



namespace Automation.Framework.Core.WebUI.Params
{
    public class GlobalProperties  : IGlobalProperties
    {
        IDefaultVariables _idefaultVariables;
        ILogging _ilogging;
        IExtentFeatureReport _iextentFeatureReport;
        public string browsertype { get; set; }
        public string gridhuburl { get; set; }
        public bool stepscreenshot { get; set; }
        public string extentreportportalurl { get; set; }
        public bool extentreporttoportal { get; set; }
        public string loglevel { get; set; }
        public string datasetlocation { get; set; }
        public string downloadedlocation { get; set; }
        public GlobalProperties(IDefaultVariables idefaultVariables,ILogging ilogging,IExtentFeatureReport iextentFeatureReport)
        {
            _idefaultVariables=idefaultVariables;
            _ilogging=ilogging;
            _iextentFeatureReport=iextentFeatureReport;
            Configuration();
        }
        public void Configuration()
        {
            var builder = (dynamic)null;
            try
            {
               builder = new ConfigurationBuilder().AddJsonFile(_idefaultVariables.getframeworkSettingjson).Build();
            }
            catch(Exception e)
            {
                _ilogging.Error("File does not exists. " + e.Message);
                System.Environment.Exit(0);
            }

            browsertype= string.IsNullOrEmpty(builder["BrowserType"]) ? "chrome" : builder["BrowserType"];
            gridhuburl = string.IsNullOrEmpty(builder["GridHubUrl"]) ? "" : builder["GridHubUrl"];
            stepscreenshot = builder["StepScreenShot"].ToLower().Equals("on") ? true : false;
            extentreportportalurl = builder["ExtentReportPortalUrl"];
            extentreporttoportal = builder["ExtentReportToPortal"].ToLower().Equals("on") ? true : false;
            loglevel = builder["LogLevel"];
            datasetlocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _idefaultVariables.dataSetLocation : builder["DataSetLocation"];
            downloadedlocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _idefaultVariables.dataSetLocation : builder["DownloadedLocation"];
            _iextentFeatureReport.InitiliazeExtentReport();
            _ilogging.LogLevel(loglevel);          

            _ilogging.Debug("********************************************************************************");
            _ilogging.Information("********************************************************************************");
            _ilogging.Information("Configuration |RUN PARAMETERS");
            _ilogging.Information("********************************************************************************");
            _ilogging.Information("Configuration|BROWSER TYPE: " + browsertype);
            _ilogging.Information("Configuration|GRID HUB URL: " + gridhuburl);
            _ilogging.Information("Configuration|STEP SCREENSHOT: " + stepscreenshot);
            _ilogging.Information("Configuration|EXTENT REPORT PORTAL URL: " + extentreportportalurl);
            _ilogging.Information("Configuration|EXTENT REPORT LOCALLY: " + extentreporttoportal);
            _ilogging.Information("Configuration|LOG LEVEL: " + loglevel);
            _ilogging.Information("Configuration|DATA SET LOCATION: " + datasetlocation);
            _ilogging.Information("Configuration|DOWNLOADED LOCATION: " + datasetlocation);
            _ilogging.Information("********************************************************************************");
            _ilogging.Information("********************************************************************************");

        }
    }
}
