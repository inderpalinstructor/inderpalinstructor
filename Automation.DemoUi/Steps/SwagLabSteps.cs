using Automation.DemoUi.WebAbstraction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUi.Steps
{
    [Binding]
    public class SwagLabSteps
    {
        ISwagLabPage _iswagLabPage;
        public SwagLabSteps(ISwagLabPage iswagLabPage)
        {
            _iswagLabPage=iswagLabPage;
        }
        [Then(@"user verifies swag lab products")]
        public void ThenUserVerifiesSwagLabProducts(Table table)
        {
            _iswagLabPage.VerifyProductItems(table);
        }

        [When(@"User cart items from product list to cart")]
        public void WhenUserCartItemsFromProductListToCart(Table table)
        {
            _iswagLabPage.SelectCartItems(table.Rows.Select(x => x["Items"].ToString()).ToList());
        }

        [Then(@"User checks count in cart of selected items")]
        public void ThenUserChecksCountInCartOfSelectedItems()
        {
            _iswagLabPage.MatchSelectedCartItems();  
        }

        [When(@"User uncart items from product list")]
        public void WhenUserUncartItemsFromProductList(Table table)
        {
            _iswagLabPage.UnCartItems(table.Rows.Select(x => x["Items"].ToString()).ToList());
        }

        [Then(@"user verifies no item in cart")]
        public void ThenUserVerifiesNoItemInCart()
        {
            _iswagLabPage.CartIsEmpty();
        }


    }
}
