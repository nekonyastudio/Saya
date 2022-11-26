namespace Saya.Core.Dto.PaginatedList;

/// <summary>
/// 分页信息
/// </summary>
public interface IPaginatedInfo
{
    /// <summary>
    /// 当前页 索引序号
    /// </summary>
    int PageIndex { get; set; }

    /// <summary>
    /// 总页数
    /// </summary>
    int TotalPages { get; set; }

    /// <summary>
    /// 总数据条目数
    /// </summary>
    long ItemCount { get; set; }
}
