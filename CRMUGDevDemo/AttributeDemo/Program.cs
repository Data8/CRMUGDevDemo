﻿using System;
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

            var createAttrReq = new CreateAttributeRequest()
            {
                EntityName = "account",
                Attribute = new StringAttributeMetadata()
                {
                    SchemaName = "data8_developerheadaches",
                    DisplayName = new Label("Custom Field 1", 1033),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    Description = new Label("String Attribute", 1033),
                    MaxLength = 26
                }
            };
            org.Execute(createAttrReq);

            var account1 = org.Retrieve("account", new Guid("3894C5BA-A4C0-E711-80DD-00155D00710B"), new ColumnSet("data8_developerheadaches"));
            account1["data8_developerheadaches"] = "abcdefghijklmnopqrstuvwxyz";
            org.Update(account1);
        }
    }
}
