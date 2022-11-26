using System;
using System.Collections.Generic;
using System.Linq;
using Saya.Core.Dto.PaginatedList;

namespace Saya.Core.PaginatedList;

/// <summary>
/// 分页列表
/// </summary>
/// <typeparam name="T"></typeparam>
public class PaginatedList<T> : List<T>, IPaginatedInfo
{
    /// <summary>
    /// 当前页 索引序号
    /// </summary>
    public int PageIndex { get; set; }

    /// <summary>
    /// 总页数
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// 总数据条目数
    /// </summary>
    public long ItemCount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="items"></param>
    /// <param name="count"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
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
            ItemCount = this.ItemCount
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
