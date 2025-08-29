using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public DateTime ModifyDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
