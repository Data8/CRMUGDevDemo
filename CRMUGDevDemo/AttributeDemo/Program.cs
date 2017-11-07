using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace AttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            const string attrname = "data8_developerheadaches";

            var crmSvc = new CrmServiceClient(ConfigurationManager.ConnectionStrings["CRMUGDemo"].ConnectionString);
            var org = crmSvc.OrganizationServiceProxy;

            var account1 = org.Retrieve("account", new Guid("3894C5BA-A4C0-E711-80DD-00155D00710B"), new ColumnSet(attrname));
            var account1Value = account1.GetAttributeValue<string>(attrname);
            Console.WriteLine(account1Value);

            var account2 = org.Retrieve("account", new Guid("3494C5BA-A4C0-E711-80DD-00155D00710B"), new ColumnSet(attrname));
            account2[attrname] = account1.GetAttributeValue<string>(attrname);
            org.Update(account2);         
        }
    }
}
