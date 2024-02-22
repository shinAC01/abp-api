using System;
using Volo.Abp.Application.Dtos;

namespace ProductManagement.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        //Los DTO(data transfer object) son objetos para pasar información entre los servicios
        //y la UI de la aplicación, los servicios son los que se encargan de implementar los
        //caso de uso, los cuales son utilizados por la UI para ejecutar la logica del negocio.

        //Realmente los DTO tienen información que no necesariamente debe ser igual a la entidad.
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool IsFreeCargo { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ProductStockState StockState { get; set; }


    }
}
