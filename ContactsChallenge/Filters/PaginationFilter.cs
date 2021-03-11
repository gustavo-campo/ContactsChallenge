using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsChallenge.Filters
{
    //filtro para el paginado de resultados
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        
        //valores por defecto
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 5;
        }

        //validamos que los valores recibidos sean validos, pageNumber igual o mayor que 1 y pageSize menor que 100
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 100 ? 100 : pageSize;
        }
    }
}
