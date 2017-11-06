using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;

namespace AttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var crmSvc = new CrmServiceClient(ConfigurationManager.ConnectionStrings["CRMUGDemo"].ConnectionString);
            var org = crmSvc.OrganizationServiceProxy;

            var createAttrReq = new CreateAttributeRequest()
            {
                EntityName = "account",
                Attribute = new StringAttributeMetadata()
                {
                    SchemaName = "address1_brandnewfield",
                    DisplayName = new Label("Address 1: Custom Field 1", 1033),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    Description = new Label("String Attribute", 1033),
                    MaxLength = 100
                }
            };

            org.Execute(createAttrReq);
        }
    }
}
