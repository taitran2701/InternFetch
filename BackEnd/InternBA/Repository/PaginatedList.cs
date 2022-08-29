using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Drawing.Printing;

namespace InternBA.Repository
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;
        public PaginatedList(List<T> items,int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

       
        public  async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var skipNumber = CaculateSkip(pageSize);
            var count = await source.CountAsync();
            var items = await source.Skip(skipNumber).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize); 
        }
        private int CaculateSkip(int pageSize) => (PageIndex - 1) * pageSize;

    }
}
