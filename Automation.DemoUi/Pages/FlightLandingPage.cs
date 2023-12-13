using Automation.DemoUi.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.Base;
using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUi.Pages
{
    public class FlightLandingPage : TestBase, IFlightLandingPage
    {
        IAtConfiguration _iatConfiguration;
        IDrivers _idriver;
        ScenarioContext _scenarioContext;

        IAtBy byCloseModal => GetBy(LocatorType.Xpath, "//span[@data-cy='closeModal']");
        IAtWebElement CloseModal => _idriver.FindElement(byCloseModal);
        IAtWebElement FromCity => _idriver.FindElement(GetBy(LocatorType.Xpath, "//input[@id='fromCity']"));

        IAtWebElement Options(string city) => _idriver.FindElement(GetBy(LocatorType.Xpath, "//p[text()='"+city+"']"));
        IAtWebElement ToCity => _idriver.FindElement(GetBy(LocatorType.Xpath, "//input[@id='toCity']"));
        IAtWebElement Departure => _idriver.FindElement(GetBy(LocatorType.Xpath, "//input[@id='travellers']/parent::label"));
        IAtWebElement Travellers => _idriver.FindElement(GetBy(LocatorType.Xpath, "//input[@id='travellers']/parent::label"));
        IAtWebElement ReturnLable => _idriver.FindElement(GetBy(LocatorType.Xpath, "//p[text()='Tap to add a return date for bigger discounts']"));
        IAtWebElement Search => _idriver.FindElement(GetBy(LocatorType.Xpath, "//p[@data-cy='submit']//a[contains(text(),'Search')]"));

        IAtWebElement CalendarView(int view) => _idriver.FindElement(GetBy(LocatorType.Xpath, "//div[@class='DayPicker-Month']["+view+"]//div[@class='DayPicker-Caption']//div"));
        IAtWebElement Day(int view, int day) => _idriver.FindElement(GetBy(LocatorType.Xpath, "//div[@class='DayPicker-Month'][" + view + "]//div[@class='dateInnerCell']//p[text()='" + day + "']"));

        IAtWebElement Arrow => _idriver.FindElement(GetBy(LocatorType.Xpath, "//span[@aria-label='Next Month']"));

        IAtWebElement Adults(int adult) => _idriver.FindElement(GetBy(LocatorType.Xpath, "//li[@data-cy='adults-"+adult+"']"));
        IAtWebElement Childers(int children) => _idriver.FindElement(GetBy(LocatorType.Xpath, "//li[@data-cy='children-"+children+"']"));
        IAtWebElement Apply => _idriver.FindElement(GetBy(LocatorType.Xpath, "//button[@type='button' and contains(text(),'APPLY')]"));
        IAtWebElement ModalClose => _idriver.FindElement(GetBy(LocatorType.Xpath, "//div[@id='webklipper-publisher-widget-container-notification-container']"));
        public FlightLandingPage(IObjectContainer iobjectContainer, IAtConfiguration iatConfiguration, IDrivers idrivers,ScenarioContext scenarioContext) 
            : base(iobjectContainer)
        {
            _iatConfiguration = iatConfiguration;
            _idriver = idrivers;
            _scenarioContext = scenarioContext;
        }

        public void NavigateToLandingPage()
        {
           string url= _iatConfiguration.GetConfiguration("guestrul");
            _idriver.NavigateTo(url);
            Thread.Sleep(3000);
            _idriver.SwitchToFrameWithName("webklipper-publisher-widget-container-notification-frame");
            _idriver.ExecuteJavaScript("document.getElementById('webklipper-publisher-widget-container-notification-close-div').click();");
            _idriver.SwitchToParentFrame();
            Thread.Sleep(3000);
            CloseModal.Click();
        }
        public void AddSearchCriteria(Table table)
        {
            NavigateToLandingPage();
            FromCity.SendKeys(table.Rows[0]["From"].Split(",")[0]);
            Options(table.Rows[0]["From"].Trim()).Click();
            ToCity.SendKeys(table.Rows[0]["To"].Split(",")[0]);
            Options(table.Rows[0]["To"].Trim()).Click();
            string departureDate= table.Rows[0]["DepartureDate"];
            string dt = string.Empty;
            switch (departureDate.Substring(1, 1).ToLower())
            {
                case "m":
                   dt= DateTime.Now.AddMonths(int.Parse(departureDate.Substring(0, 1))).ToString("MMMM yyyy-d");
                    break;
                default:
                    dt = DateTime.Now.AddDays(int.Parse(departureDate.Substring(0, 1))).ToString("MMMM yyyy-d");
                    break;
            }
            // dt ="January 2024-2"

            for(int i = 0; i < 6; i++)
            {
                if (dt.Substring(0, dt.IndexOf("-")).Equals(CalendarView(1).GetText().Trim()))
                {
                    Day(1, int.Parse(dt.Substring(0, dt.IndexOf("-") + 1)));
                    break;
                }
                else if(dt.Substring(0, dt.IndexOf("-")).Equals(CalendarView(2).GetText().Trim()))
                {
                    Day(2, int.Parse(dt.Substring(dt.IndexOf("-") + 1))).Click();
                    break;
                }
                else
                {
                    Arrow.Click();
                }
            }

            Travellers.Click();
            Adults(int.Parse(table.Rows[0]["Travellers"].Substring(0, 1))).Click();
            Childers(int.Parse(table.Rows[0]["Travellers"].Substring(2, 1))).Click();
            Apply.Click();
            _scenarioContext["searchCriteria"] = table;
            
        }

        public void NavigateToFlightListingPage()
        {
            Search.Click();
        }
    }
}
