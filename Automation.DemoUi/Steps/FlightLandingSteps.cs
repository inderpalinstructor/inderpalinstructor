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
    public class FlightLandingSteps
    {
        IFlightLandingPage _iflightLandingPage;
        public FlightLandingSteps(IFlightLandingPage iflightLandingPage)
        {
            _iflightLandingPage = iflightLandingPage;
        }
        [Given(@"user enters flight search criteria on the flight landing page")]
        public void GivenUserEntersFlightSearchCriteriaOnTheFlightLandingPage(Table table)
        {
           _iflightLandingPage.AddSearchCriteria(table);
        }

        [When(@"user navigates to flight listing page")]
        public void WhenUserNavigatesToFlightListingPage()
        {
            _iflightLandingPage.NavigateToFlightListingPage();
        }

    }
}
