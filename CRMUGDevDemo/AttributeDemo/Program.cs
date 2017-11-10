using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var crmSvc = new CrmServiceClient(ConfigurationManager.ConnectionStrings["CRMUGDemo"].ConnectionString);
            var org = crmSvc.OrganizationServiceProxy;

            var account1 = org.Retrieve("account", new Guid("3894C5BA-A4C0-E711-80DD-00155D00710B"), new ColumnSet("address1_line1"));
            account1["address1_line1"] = "Line 1";
            org.Update(account1);

            var account2 = org.Retrieve("account", new Guid("3894C5BA-A4C0-E711-80DD-00155D00710B"), new ColumnSet("address1_brandnewfield"));
            account2["address1_line1"] = "Line 1";
            account2["address1_brandnewfield"] = "brand new value";
            org.Update(account2);
        }
    }
}
