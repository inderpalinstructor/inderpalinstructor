using Automation.DemoUi.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.Base;
using BoDi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUi.Pages
{
    public class FligtListingPage : TestBase, IFlightListingPage
    {
        IAtConfiguration _iatConfiguration;
        IDrivers _idriver;
        ScenarioContext _sc;
        IAtWebElement from => _idriver.FindElement(GetBy(LocatorType.Xpath, "//input[@id='fromCity']"));
        public FligtListingPage(IObjectContainer iobjectContainer, IAtConfiguration iatConfiguration, IDrivers idrivers,ScenarioContext sc)
           : base(iobjectContainer)
        {
            _iatConfiguration = iatConfiguration;
            _idriver = idrivers;
            _sc = sc;
        }

        public void VerifySearchCriteria()
        {
            Table table =(Table) _sc["searchCriteria"];
            Assert.AreEqual(from.GetAttribute("value").Trim(), table.Rows[0]["From"].Trim());
        }
    }
}
