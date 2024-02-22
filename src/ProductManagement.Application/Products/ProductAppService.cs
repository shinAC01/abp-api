using AutoMapper.Internal.Mappers;
using ProductManagement.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Products
{
    /*
        La clase ProductAppService se deriva de ProductManagementAppService, la cual viene definida en 
    el template inicial.
        Recordar que en la logica del backend, se crea una interface con los metodos (IAppService),
        dichos servicios se implementan en la clase AppService, y luego para utilizar dichos servicios,
        se inyecta la interface en la clase necesaria o vista, dado que ABP tiene el auto mapper, no hay
        que crear controladores para los endpoints por el momento, asi que directamente se consumen los
        servicios.
     */
    public class ProductAppService : ProductManagementAppService, IProductAppService
    {
        //Esto es una inyeccion de dependencia en C#, es un Default Repository, una colección de interfaces
        //que permiten interactuar con las tablas de nuestra base de datos.
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<Category, Guid> _categoryRepository;

        public ProductAppService(IRepository<Product, Guid> productRepository, IRepository<Category, Guid> categoryRepository)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
        }

        public async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //la siguiente variable devuelve un IQueryable<Product> que es una extension para realizar consultas
            //eficientes a la base de datos directamente desde C#.
            var queryable = await _productRepository.WithDetailsAsync(x => x.Category);

            queryable = queryable
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .OrderBy(input.Sorting ?? nameof(Product.Name));

            //El AsyncExecuter se usa para ejecutar IQueryable y entonces hacer una consula a la base de datos
            //segun lo que devuelve al llamar ToListAsync con queryable.
            var products = await AsyncExecuter.ToListAsync(queryable);
            var count = await _productRepository.GetCountAsync();

            return new PagedResultDto<ProductDto>(
                count,
                ObjectMapper.Map<List<Product>, List<ProductDto>>(products)
            );
        }

        public async Task CreateAsync(CreateUpdateProductDto input)
        {
            await _productRepository.InsertAsync(ObjectMapper.Map<CreateUpdateProductDto, Product>(input));
        }
        public async Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetListAsync();
            return new ListResultDto<CategoryLookupDto>(
            ObjectMapper
            .Map<List<Category>, List<CategoryLookupDto>>
           (categories)
            );
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            var product = await _productRepository.GetAsync(id);
            ObjectMapper.Map(input, product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}

