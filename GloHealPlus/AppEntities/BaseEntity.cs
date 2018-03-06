using System;

namespace DomainEntities
{
    public abstract class BaseEntity
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy {get;set;}
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool? IsDeleted { get; set; } = false;
    }
}
