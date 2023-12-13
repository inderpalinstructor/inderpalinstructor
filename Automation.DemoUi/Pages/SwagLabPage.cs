using Automation.DemoUi.DataTables;
using Automation.DemoUi.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.Base;
using Automation.Framework.Core.WebUI.DriverContext;
using BoDi;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Automation.DemoUi.Pages
{
    public class SwagLabPage : TestBase, ISwagLabPage
    {
        IAtConfiguration _iatConfiguration;
        IDrivers _idriver;
        ScenarioContext _scenarioContext;
        IAtBy byProductItems=> GetBy(LocatorType.Xpath, "//div[@class='inventory_list']/div");
        IAtWebElement ProductItems => _idriver.FindElement(byProductItems);
        IAtBy byProductName(int index) => GetBy(LocatorType.Xpath, "//div[@class='inventory_list']/div["+index+"]//div[contains(@class,'inventory_item_name')]");
        IAtWebElement ProductName(int index) => _idriver.FindElement(byProductName(index));

        IAtBy byProductPrice(int index) => GetBy(LocatorType.Xpath, "//div[@class='inventory_list']/div["+index+"]//div[@class='inventory_item_price']");
        IAtWebElement ProductPrice(int index) => _idriver.FindElement(byProductPrice(index));

        IAtBy byAddCart(int index) => GetBy(LocatorType.Xpath, "//div[@class='inventory_list']/div[" + index + "]/div[@class='inventory_item_description']//button");
        IAtWebElement AddCart(int index) => _idriver.FindElement(byAddCart(index));

        IAtBy byShoppingCartBadge => GetBy(LocatorType.Xpath, "//div[@id='shopping_cart_container']//span");
        IAtWebElement ShoppingCartBadge => _idriver.FindElement(byShoppingCartBadge);
        int intCartBadge => _idriver.FindElementsCount(byShoppingCartBadge);
        IAtBy byCartContainer => GetBy(LocatorType.Xpath, "//div[@id='shopping_cart_container']//a[@class='shopping_cart_link']");

        IAtWebElement CartContainer => _idriver.FindElement(byCartContainer);

        public SwagLabPage(IObjectContainer iobjectContainer, IAtConfiguration iatConfiguration, IDrivers idrivers,ScenarioContext scenarioContext) 
            : base(iobjectContainer)
        {
            _iatConfiguration = iatConfiguration;
            _idriver = idrivers;
            _scenarioContext = scenarioContext;
        }

        public void VerifyProductItems(Table table)
        {
            Table tableProduct = new Table(new string[] { "Item", "Price" });
            int count = ProductItems.NumberOfElement;
            for(int i = 1; i <= count; i++)
            {               
               tableProduct.AddRow(ProductName(i).GetText(), ProductPrice(i).GetText());                
            }            

           Assert.AreEqual(tableProduct.ToProjection<Product>().Except(table.ToProjection<Product>()).Count(),0);
        }

        public void SelectCartItems(IList<string> cartItems)
        {
            CartUnCartItems(cartItems,"Remove");
            _scenarioContext["cartItems"] = cartItems;
        }

        public void MatchSelectedCartItems()
        {
            IList<string> cartItems =(IList<string>) _scenarioContext["cartItems"];
            Assert.AreEqual(int.Parse(ShoppingCartBadge.GetText()), cartItems.Count);
        }

        public void UnCartItems(IList<string> cartItems)
        {
            CartUnCartItems(cartItems, "Add to cart");
            IList<string> scCartItems =(IList<string>) _scenarioContext["cartItems"];
            foreach(string item in cartItems)
            {
                scCartItems.Remove(item);
            }
            _scenarioContext["cartItems"] = scCartItems;
        }

        private void CartUnCartItems(IList<string> cartItems,string lable)
        {
            int count = ProductItems.NumberOfElement;
            for (int i = 1; i < count; i++)
            {
                if (cartItems.Contains(ProductName(i).GetText().Trim()))
                {
                    AddCart(i).Click();
                    Thread.Sleep(500);
                    Assert.AreEqual(AddCart(i).GetText(), lable);
                }
            }
        }

        public void CartIsEmpty()
        {
            Assert.IsEmpty(CartContainer.GetText().Trim());
        }
    }
}
