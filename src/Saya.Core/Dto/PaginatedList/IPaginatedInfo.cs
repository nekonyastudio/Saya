using System.Collections.Generic;

namespace Saya.Core.Dto.PaginatedList
{
    /// <summary>
    /// 分页信息
    /// </summary>
    public interface IPaginatedInfo
    {
        int PageIndex { get; set; }
        int TotalPages { get; set; }
        long ItemCount { get; set; }
    }
}
