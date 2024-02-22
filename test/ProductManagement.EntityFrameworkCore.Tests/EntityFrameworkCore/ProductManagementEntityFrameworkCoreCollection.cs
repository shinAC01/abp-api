using Xunit;

namespace ProductManagement.EntityFrameworkCore;

[CollectionDefinition(ProductManagementTestConsts.CollectionDefinitionName)]
public class ProductManagementEntityFrameworkCoreCollection : ICollectionFixture<ProductManagementEntityFrameworkCoreFixture>
{

}
