using System;
using System.Collections.Generic;
using System.Linq;
using Saya.Core.Dto.PaginatedList;

namespace Saya.Core.PaginatedList
{
    /// <summary>
    /// 分页列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginatedList<T> : List<T>, IPaginatedInfo
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public long ItemCount { get; set; }

        public PaginatedList(IList<T> items, long count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);

            ItemCount = count;
        }

        public PaginatedListDto<T> GetDto()
        {
            return new PaginatedListDto<T>
            {
                Data = this,
                PageIndex = this.PageIndex,
                TotalPages = this.TotalPages,
                ItemCount = this.Count
            };
        }

        /// <summary>
        /// 得到类型不同的DTO
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public PaginatedListDto<TDto> GetDto<TDto>(Func<T, TDto> selector)
        {
            return new PaginatedListDto<TDto>
            {
                Data = this.Select(selector),
                PageIndex = this.PageIndex,
                TotalPages = this.TotalPages,
                ItemCount = this.ItemCount
            };
        }

    }
}
