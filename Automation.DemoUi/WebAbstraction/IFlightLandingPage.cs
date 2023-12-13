using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUi.WebAbstraction
{
    public interface IFlightLandingPage
    {
        void AddSearchCriteria(Table table);
        void NavigateToFlightListingPage();
    }
}
