using ProductManagement.Categories;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ProductManagement.Products
{
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        //FullAuditedAggregateRoot añade ademas IsDeleted, DeletionTime, DeleterId...
        //Esto hace la entidad Soft-Delete, lo que hace es que no pueda ser eliminada jamas, simplemente
        //parece como eliminada, pero sigue ahi oculta.
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool IsFreeCargo { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ProductStockState StockState { get; set; }
    }
}
