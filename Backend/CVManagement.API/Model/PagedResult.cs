using System.Collections.Generic;

namespace CVManagement.API.Model
{
    public class PagedResult<T>
    {
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<T> Data { get; set; }
    }
}
