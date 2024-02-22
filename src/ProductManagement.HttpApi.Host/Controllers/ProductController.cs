using Microsoft.AspNetCore.Mvc;
using ProductManagement.Products;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ProductManagement.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {

        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        public async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var products = await _productAppService.GetListAsync(input);
            return products;
        }
        [HttpPut]
        [Route("{id}")]
        public async Task UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            await _productAppService.UpdateAsync(id, input);
        }

    }
}
