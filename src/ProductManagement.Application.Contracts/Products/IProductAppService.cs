using ProductManagement.Categories;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProductManagement.Products
{
    //Las interfaces son necesarias para ser utilizadas en los servicios, son las que definen
    //Los métodos para luego ser implementados en los servicios.

    //
    public interface IProductAppService : IApplicationService
    {
        //El siguiente método es una clase estandar de ABP (PagedAndSortedResultRequestDto)
        //que define los metodos MaxResultCount(int), SkipCount(int) y Sorting (string)

        //MaxResultCount lo que hace es decir la maxima cantidad de registros a devolver
        //SkipCount pos la cantidad de registros que se va a saltar antes de empezar a devolverlos
        //Sorting es la forma de ordenar los recursos, recibe un string xq la orden se da asi

        Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        //Dicho metodo returna un PagedResultDto<ProductDto> que es una clase que returna un conteo
        //de la cantidad de objetos y ademas devuelve una lista de ProductsDto. (generalmente se utiliza
        //en ABP para devolver cosas)

        Task CreateAsync(CreateUpdateProductDto input);
        Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync();
        Task<ProductDto> GetAsync(Guid id);
        Task UpdateAsync(Guid id, CreateUpdateProductDto input);
        Task DeleteAsync(Guid id);
    }
}
