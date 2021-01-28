using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Saya.Web.Dto.PaginatedList;

namespace Saya.Web.Utils.PaginatedList
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public int ItemCount { get; set; }

        public PaginatedList(IList<T> items, int count, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);

            this.ItemCount = count;
        }

        /// <summary>
        /// 创建分页数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }


        public PaginatedListDto<T> GetDto()
        {
            return new PaginatedListDto<T>
            {
                Data = this,
                PageIndex = this.PageIndex,
                TotalPages = this.TotalPages,
                ItemCount = this.ItemCount
            };
        }

        /// <summary>
        /// 得到类型不同的Dto
        /// </summary>
        /// <typeparam name="TNewType"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public PaginatedListDto<TNewType> GetDto<TNewType>(Func<T, TNewType> selector)
        {
            return new PaginatedListDto<TNewType>
            {
                Data = this.Select(selector),
                PageIndex = this.PageIndex,
                TotalPages = this.TotalPages,
                ItemCount = this.ItemCount
            };
        }

    }
}
