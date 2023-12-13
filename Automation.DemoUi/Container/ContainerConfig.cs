using Automation.DemoUi.Configuration;
using Automation.DemoUi.Pages;
using Automation.DemoUi.Steps;
using Automation.DemoUi.WebAbstraction;
using Automation.Framework.Core.WebUI.DIContainer;
using BoDi;
using TechTalk.SpecFlow;

namespace Automation.DemoUi.Container
{
    [Binding]
    public class ContainerConfig
    {
        [BeforeScenario(Order =1)]
        public void BeforeScenario(IObjectContainer iobjectContainer)
        {
            iobjectContainer.RegisterTypeAs<AtConfiguration, IAtConfiguration>();
            iobjectContainer.RegisterTypeAs<LoginPage, ILoginPage>();
            iobjectContainer.RegisterTypeAs<SwagLabPage, ISwagLabPage>();
            iobjectContainer.RegisterTypeAs<FlightLandingPage, IFlightLandingPage>();
            iobjectContainer.RegisterTypeAs<FligtListingPage, IFlightListingPage>();
            iobjectContainer = CoreContainerConfig.SetContainer(iobjectContainer);
        }
    }
}
