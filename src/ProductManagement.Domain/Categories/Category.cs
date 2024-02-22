using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ProductManagement.Categories
{
    public class Category : AuditedAggregateRoot<Guid>
    {
        /*
         Recordar que al heredar de AuditedAggregateRoot hereda atributos como:
         CreationTime, DateTime, CreatorId, Guid, LastModificationTime y DateTime
        */
        public string Name { get; set; }
    }
}
