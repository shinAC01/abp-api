using AutoMapper;
using ProductManagement.Categories;
using ProductManagement.Products;

namespace ProductManagement;

public class ProductManagementApplicationAutoMapperProfile : Profile
{
    public ProductManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Product, ProductDto>();
        CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<Category, CategoryLookupDto>();
        //Convierte del primer objeto al segundo objeto, algunas cosas, en este caso, la entidad pesada
        //Se pone primero y de segundo la sencilla, es decir, por ejplo aqui con el Flattening:
        //Por ejplo: Product depende de Category para acceder a su Name atributo, pero sin embargo
        //ProductDto tiene CategoryName como un atributo, entonces el AutoMapper convierte lo de 
        //Product.Category.Name a simplemente Product.CategoryName
        //(Es un poco complicado de entender y tal, pero es más o menos así)

    }
}
