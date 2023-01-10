using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManagement.Domain
{
    public class Entity<TId> : ISoftDelete
    {
        public TId Id { get; set; }
        public bool IsDeleted { get ; set; }
    }
}
