using Microsoft.Xrm.Sdk;
using System;

namespace Mppce.PowerAutomateExtendedTriggers.Plugins
{
    public class OnPublish : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.ResolvePluginExecutionContext();

            string message;
            try
            {
                message = context.MessageName;
            } catch
            {
                message = "PublishAll";
            }

            var service = serviceProvider.ResolveOrganizationServiceAsAdmin();

            var request = new OrganizationRequest($"mppce_OnPublish");
            request["Message"] = message;
            service.Execute(request);
        }
    }
}
