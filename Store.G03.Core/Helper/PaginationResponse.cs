using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G03.Core.Helper
{
    public class PaginationResponse<TEntity>
    {
        public PaginationResponse(int pageSize, int pageIndex, int count, IEnumerable<TEntity> date)
        {
            this.pageSize = pageSize;
            this.pageIndex = pageIndex;
            this.count = count;
            Date = date;
        }

        public int pageSize {  get; set; }
        public int pageIndex {  get; set; }
        public int count {  get; set; }
        public IEnumerable<TEntity>Date {  get; set; }
    }
}
