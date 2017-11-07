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
            var crmSvc = new CrmServiceClient(ConfigurationManager.ConnectionStrings["CRMUGDemo"].ConnectionString);
            var org = crmSvc.OrganizationServiceProxy;

            // Load 1 account and store the value thats safely stored in CRM
            var account1 = org.Retrieve("account", new Guid("3894C5BA-A4C0-E711-80DD-00155D00710B"), new ColumnSet("data8_developerheadaches"));
            var account1Value = account1.GetAttributeValue<string>("data8_developerheadaches");
            Console.WriteLine($"data8_developerheadaches: {account1Value}");

            // Try to re-use that value anywhere else
            var account2 = org.Retrieve("account", new Guid("3494C5BA-A4C0-E711-80DD-00155D00710B"), new ColumnSet("data8_developerheadaches"));
            account2["data8_developerheadaches"] = account1.GetAttributeValue<string>("data8_developerheadaches");
            org.Update(account2);         
        }
    }
}
