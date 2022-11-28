using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectAPI.Utils
{

    public static class QueryableExtensions
    {
        public static PaginationResult<T> Paginate<T>(
            this IQueryable<T> source,
            IPaginationInfo pagination)
        {
            PaginationResult<T> results = new PaginationResult<T>();
            results.total = source.Count();
            results.page = pagination.PageNumber + 1;

            results.data = source
                .Skip(pagination.PageNumber * pagination.PageSize)
                .Take(pagination.PageSize);

            return results;
        }
    }

    public abstract class QueryArgsBase : IPaginationInfo
    {
        [BindRequired]
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class PaginationResult<T>
    {
        public int page { get; set; }
        public int total { get; set; }
        public IQueryable<T> data { get; set; }
    }
    public class PaginationListResult<T>
    {
        public int page { get; set; }
        public int total { get; set; }
        public IEnumerable<T> data { get; set; }
    }

    public class DefaultArgs : QueryArgsBase
    {
        public string Filter { get; set; }
    }   

    public interface IPaginationInfo
    {
        int PageNumber { get; }
        int PageSize { get; }
    }
}