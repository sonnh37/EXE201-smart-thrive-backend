﻿using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

public abstract class BaseQuery
{
}

public class GetQueryableQuery : BaseQuery
{
    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public bool IsPagination { get; set; } = false;

    public Guid Id { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool? IsDeleted { get; set; }


    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public string? SortField { get; set; }

    public SortOrder? SortOrder { get; set; } = Enums.SortOrder.Ascending;
}

public class GetByIdQuery : BaseQuery
{
    public Guid Id { get; set; }
}

public class GetAllQuery : GetQueryableQuery
{
}