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
    public class LoginStep
    {
        ILoginPage _iloginPage;
        public LoginStep(ILoginPage iloginPage)
        {
            _iloginPage = iloginPage;
        }

        [Given(@"login with valid credentials")]
        public void GivenLoginWithValidCredentials()
        {
            _iloginPage.LoginWithValidCrendentials();
        }

    }
}
