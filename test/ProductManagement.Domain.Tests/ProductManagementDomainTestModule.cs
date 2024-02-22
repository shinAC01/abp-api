using Volo.Abp.Modularity;

namespace ProductManagement;

[DependsOn(
    typeof(ProductManagementDomainModule),
    typeof(ProductManagementTestBaseModule)
)]
public class ProductManagementDomainTestModule : AbpModule
{

}
