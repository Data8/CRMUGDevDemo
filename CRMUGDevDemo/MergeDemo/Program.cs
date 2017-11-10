using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace MergeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var crmSvc = new CrmServiceClient(ConfigurationManager.ConnectionStrings["CRMUGDemo"].ConnectionString);
            var org = crmSvc.OrganizationServiceProxy;

            var contact1 = org.Retrieve("contact", new Guid("{FB2FB326-A9C0-E711-80DB-00155D007101}"), new ColumnSet("telephone1", "transactioncurrencyid"));
            var contact2 = org.Retrieve("contact", new Guid("{9F59035D-A9C0-E711-80DB-00155D007101}"), new ColumnSet("telephone1", "transactioncurrencyid"));
            
            org.Execute(new MergeRequest
            {
                Target = contact1.ToEntityReference(),
                SubordinateId = contact2.Id,
                UpdateContent = new Entity("contact")
                {
                    ["telephone1"] = contact2["telephone1"]
                }
            });
        }
    }
}
