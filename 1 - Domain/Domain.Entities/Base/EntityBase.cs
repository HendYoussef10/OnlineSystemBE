using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Base
{
    public class EntityBase
    {
        public Guid Id {  set; get; } = Guid.NewGuid();
        public bool IsDeleted { set; get; }
        public DateTime CreatedDate {  set; get; } = DateTime.UtcNow;

    }
}
