using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Utilities;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

public abstract class BaseQuery
{
}

public class GetQueryableQuery : BaseQuery
{
    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public bool IsPagination { get; set; } = ConstantHelper.IsPagination;

    public Guid? Id { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public List<bool?>? IsDeleted { get; set; }

    public int PageNumber { get; set; } = ConstantHelper.PageNumberDefault;

    public int PageSize { get; set; } = ConstantHelper.PageSizeDefault;

    public string? SortField { get; set; } = ConstantHelper.SortFieldDefault;

    public SortOrder? SortOrder { get; set; } = ConstantHelper.SortOrderDefault;
}

public class GetByIdQuery : BaseQuery
{
    public Guid? Id { get; set; }
}

public class GetAllQuery : GetQueryableQuery
{
}