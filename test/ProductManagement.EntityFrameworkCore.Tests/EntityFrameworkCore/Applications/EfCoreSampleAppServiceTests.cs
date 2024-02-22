using ProductManagement.Samples;
using Xunit;

namespace ProductManagement.EntityFrameworkCore.Applications;

[Collection(ProductManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ProductManagementEntityFrameworkCoreTestModule>
{

}
