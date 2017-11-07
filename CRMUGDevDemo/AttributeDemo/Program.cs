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
            const string attrname = "data8_developerheadaches";

            var crmSvc = new CrmServiceClient(ConfigurationManager.ConnectionStrings["CRMUGDemo"].ConnectionString);
            var org = crmSvc.OrganizationServiceProxy;

            var deleteAttrReq = new DeleteAttributeRequest()
            {
                EntityLogicalName = "account",
                LogicalName = attrname
            };
            org.Execute(deleteAttrReq);

            var createAttrReq = new UpdateAttributeRequest()
            {
                EntityName = "account",
                Attribute = new StringAttributeMetadata()
                {
                    SchemaName = attrname,
                    DisplayName = new Label("Custom Field 1", 1033),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    Description = new Label("String Attribute", 1033),
                    MaxLength = 26
                }
            };

            var account1 = org.Retrieve("account", new Guid("3894C5BA-A4C0-E711-80DD-00155D00710B"), new ColumnSet(attrname));
            account1[attrname] = "abcdefghijklmnopqrstuvwxyz";
            org.Update(account1);
        }
    }
}
