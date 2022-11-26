using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Saya.Core.PaginatedList;

namespace Saya.EntityFramework.Helper;

public static class EFCorePaginatedListHelper
{
    public static async Task<PaginatedList<T>> CreateAsync<T>(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = await source.LongCountAsync();
        var items = await source
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }
}
