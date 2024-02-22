using ProductManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ProductManagement.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProductManagementEntityFrameworkCoreModule),
    typeof(ProductManagementApplicationContractsModule)
    )]
public class ProductManagementDbMigratorModule : AbpModule
{
}
