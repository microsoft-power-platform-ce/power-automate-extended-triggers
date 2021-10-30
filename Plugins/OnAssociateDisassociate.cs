using Microsoft.Xrm.Sdk;
using System;

namespace Mppce.PowerAutomateExtendedTriggers.Plugins
{
    public class OnAssociateDisassociate : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.ResolvePluginExecutionContext();

            var message = context.MessageName;

            var target = (EntityReference)context.InputParameters["Target"];
            var relatedEntities = (EntityReferenceCollection)context.InputParameters[
                "RelatedEntities"
            ];
            var relationship = (Relationship)context.InputParameters["Relationship"];

            var service = serviceProvider.ResolveOrganizationServiceAsAdmin();

            foreach (var relatedEntity in relatedEntities)
            {
                var request = new OrganizationRequest($"mppce_OnAssociateDisassociate");
                request["Message"] = message;
                request["Relationship"] = relationship.SchemaName;
                request["Entity1"] = target;
                request["Entity2"] = relatedEntity;

                service.Execute(request);
            }
        }
    }
}
