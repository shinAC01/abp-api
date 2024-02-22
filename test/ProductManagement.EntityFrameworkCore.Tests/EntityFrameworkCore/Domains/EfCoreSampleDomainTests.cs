using ProductManagement.Samples;
using Xunit;

namespace ProductManagement.EntityFrameworkCore.Domains;

[Collection(ProductManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ProductManagementEntityFrameworkCoreTestModule>
{

}
