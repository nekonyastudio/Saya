namespace Saya.Web.Dto.PaginatedList
{
    public interface IPaginatedInfo
    {
        int PageIndex { get; }
        int TotalPages { get; }
        long ItemCount { get; }
    }
}
