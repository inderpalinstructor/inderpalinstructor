using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUi.WebAbstraction
{
    public interface ISwagLabPage
    {
        void VerifyProductItems(Table table);
        void SelectCartItems(IList<string> cartItems);
        void MatchSelectedCartItems();
        void UnCartItems(IList<string> cartItems);
        void CartIsEmpty();


    }
}
