using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.CustomException
{
    public enum ErrorItems
    {
        /// <summary>
        /// Invalid DB Credentials
        /// </summary>
        InvalidDBCredential,
        /// <summary>
        /// Invalid Klov Report Credentials
        /// </summary>
        InvalidKlovReportCredential,
        /// <summary>
        /// Report config missing
        /// </summary>
        InvalidReportConfigFile,
        /// <summary>
        /// Specflow scenario not found
        /// </summary>
        ScenarioNotFound,
        /// <summary>
        /// Feature name is invalid
        /// </summary>
        InvalidFeatureFile,
        /// <summary>
        /// InvalidSQLQuery
        /// </summary>
        InvalidSqlQueryException,
        /// <summary>
        /// Invalid Parameters
        /// </summary>
        InvalidParameterException,
        /// <summary>
        /// Duplicate TestObject
        /// </summary>
        DuplicateTestObjectException,
        /// <summary>
        /// User stopped execution
        /// </summary>
        UserStoppedException,
        /// <summary>
        /// Wait time out
        /// </summary>
        WaitTimedOutException,
        /// <summary>
        /// Element Exception
        /// </summary>
        ElementException,
        /// <summary>
        /// Stale Element
        /// </summary>
        StaleElementException,
        /// <summary>
        /// No such element visible
        /// </summary>
        NoSuchAttributeException,
        /// <summary>
        /// No Attribute value found
        /// </summary>
        AttributeValueNotMatched,
        /// <summary>
        /// Soap Template file name is invalid
        /// </summary>
        InvalidSoapRequestFile

    }
}
