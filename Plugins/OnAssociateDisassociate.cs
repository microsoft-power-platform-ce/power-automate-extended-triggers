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
                CallAction(service, message, relationship.SchemaName, relatedEntity, target);
                CallAction(service, message, relationship.SchemaName, target, relatedEntity);
            }
        }

        private void CallAction(
            IOrganizationService service,
            string message,
            string relationship,
            EntityReference entity1,
            EntityReference entity2
        ) {
            var request = new OrganizationRequest($"mppce_OnAssociateDisassociate");
            request["Message"] = message;
            request["Relationship"] = relationship;
            request["Entity1"] = entity1;
            request["Entity2"] = entity2;

            service.Execute(request);
        }
    }
}
