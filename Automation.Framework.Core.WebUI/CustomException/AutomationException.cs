using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.CustomException
{
    public class AutomationException: Exception
    {
        
        public AutomationException(string message) : base(message) { }

        public AutomationException(ErrorItems errorItems) : base($"{errorItems}") { }

        public AutomationException(ErrorItems errorItems,string message) : base($"{errorItems} : {message}" )
        {

        }
        
    }
}
