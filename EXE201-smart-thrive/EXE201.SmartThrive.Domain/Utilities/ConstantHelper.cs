using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Utilities;

public class ConstantHelper
{
    public const string Success = "Success";
    public const string Fail = "Fail";
    public const string NotFound = "Not Found";
    public const string NoContent = "No Content";
    public const string Duplicate = "Data was exist";

    public const string Categories = "api/categories";
    public const string Subjects = "api/subjects";
    public const string Vouchers = "api/vouchers";
    public const string Blogs = "api/blogs";
    public const string Modules = "api/modules";
    public const string Feedbacks = "api/feedbacks";
    public const string Orders = "api/orders";
    public const string Courses = "api/courses";
    public const string Providers = "api/providers";
    public const string Sessions = "api/sessions";
    public const string Users = "api/users";
    public const string Students = "api/students";
    
    public const string SortFieldDefault = "CreatedDate";
    public const int PageNumberDefault = 1;
    public const int PageSizeDefault = 10;
    public const SortOrder SortOrderDefault = SortOrder.Ascending;
}