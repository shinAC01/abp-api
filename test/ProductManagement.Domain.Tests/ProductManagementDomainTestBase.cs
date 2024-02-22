using Volo.Abp.Modularity;

namespace ProductManagement;

/* Inherit from this class for your domain layer tests. */
public abstract class ProductManagementDomainTestBase<TStartupModule> : ProductManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
