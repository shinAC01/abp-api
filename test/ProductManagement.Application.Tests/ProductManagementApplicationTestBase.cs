using Volo.Abp.Modularity;

namespace ProductManagement;

public abstract class ProductManagementApplicationTestBase<TStartupModule> : ProductManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
