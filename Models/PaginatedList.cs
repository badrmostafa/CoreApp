using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class PaginatedList<P> : List<P> where P:class
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; set; }
        public PaginatedList(List<P> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        public bool PreviousPage
        {
            get
            {
                return PageIndex > 1;
            }
        }
        public bool NextPage
        {
            get
            {
                return PageIndex < TotalPages;
            }
        }
        public static PaginatedList<P> Create(IEnumerable<P> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<P>(items, count, pageIndex, pageSize);
        }
    }
}
