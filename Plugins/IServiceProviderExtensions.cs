using Microsoft.Xrm.Sdk;
using System;

namespace Mppce.PowerAutomateExtendedTriggers.Plugins
{
    static class IServiceProviderExtensions
    {
        public static IOrganizationService ResolveOrganizationServiceAsAdmin(
            this IServiceProvider serviceProvider
        ) => serviceProvider.ResolveOrganizationServiceFactory().CreateOrganizationService(null);

        static IOrganizationServiceFactory ResolveOrganizationServiceFactory(
            this IServiceProvider serviceProvider
        ) => serviceProvider.Resolve<IOrganizationServiceFactory>();

        public static IPluginExecutionContext ResolvePluginExecutionContext(
            this IServiceProvider serviceProvider
        ) => serviceProvider.Resolve<IPluginExecutionContext>();

        static TOutput Resolve<TOutput>(this IServiceProvider serviceProvider) =>
            (TOutput)serviceProvider.GetService(typeof(TOutput));
    }
}
