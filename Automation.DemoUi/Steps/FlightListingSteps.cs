using Automation.DemoUi.WebAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUi.Steps
{
    [Binding]
    public class FlightListingSteps
    {        
        IFlightListingPage _iflightListingPage;
        public FlightListingSteps(IFlightListingPage flightListingPage)
        {
            _iflightListingPage = flightListingPage;
        }

        [Then(@"user verifies search criteria on the flight listing page")]
        public void ThenUserVerifiesSearchCriteriaOnTheFlightListingPage()
        {
            _iflightListingPage.VerifySearchCriteria();
        }

    }
}
