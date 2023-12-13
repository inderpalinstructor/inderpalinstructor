using Automation.Framework.Core.WebUI.Abstraction;
using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Base
{
    public class TestBase
    {

        IObjectContainer _iobjectContainer;
        public TestBase(IObjectContainer objectContainer)
        {
            _iobjectContainer = objectContainer;
        }

        public IAtBy GetBy(LocatorType type,string value)
        {
            By by;
            IAtBy iatBy = _iobjectContainer.Resolve<IAtBy>();
            switch(type)
            {
                case LocatorType.Xpath:
                    by=By.XPath(value);
                    break;
                case LocatorType.Id:
                    by = By.Id(value);
                    break;
                default:
                    by=By.XPath(value);
                    break;
            }
            iatBy.By = by;
            return iatBy;

        }

    }
}
