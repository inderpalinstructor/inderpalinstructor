using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstraction
{
    public interface IAtWebElement
    {
        void Set(IWebDriver iwebDriver, IAtBy iatBy);
        void Click();
        void SendKeys(string text);
        void ClearText();
        string GetText();
        string GetAttribute(string attributeName);
        void MouseHover();
        bool IsDisplayed();
        void DoubleClick();
        void ClickWithJs();
        IWebElement GetElement();
        int NumberOfElement { get; }
        bool Enabled { get; }
        IAtBy GetBy();
        void ClickIfVisible();

    }
}
