using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Utilities;

public class Const
{
    #region Error Codes

    public static int ERROR_EXCEPTION_CODE = -4;
    

    #endregion

    #region Success Codes

    public static int SUCCESS_CODE = 1;
    public static string SUCCESS_CREATE_MSG = "Save data success";
    public static string SUCCESS_READ_MSG = "Get data success";
    public static string SUCCESS_UPDATE_MSG = "Update data success";
    public static string SUCCESS_DELETE_MSG = "Delete data success";
    public static string SUCCESS_LOGIN_MSG = "Login success";


    #endregion

    #region Fail code

    public static int FAIL_CODE = -1;
    public static string FAIL_CREATE_MSG = "Save data fail";
    public static string FAIL_READ_MSG = "Get data fail";
    public static string FAIL_UPDATE_MSG = "Update data fail";
    public static string FAIL_DELETE_MSG = "Delete data fail";

    #endregion

    #region Warning Code

    public static int WARNING_NO_DATA_CODE = 4;
    public static string WARNING_NO_DATA_MSG = "No data";
    
    #endregion
    
    #region Not Found Codes

    public static int NOT_FOUND_CODE = -2; 
    public static string NOT_FOUND_MSG = "Not found";
    public static string NOT_USERNAME_MSG = "Not found username";
    public static string NOT_PASSWORD_MSG = "Not match password";

    #endregion
}
public class ConstantHelper
{

    public const string Categories = "api/categories";
    public const string Subjects = "api/subjects";
    public const string Vouchers = "api/vouchers";
    public const string Blogs = "api/blogs";
    public const string Modules = "api/modules";
    public const string Feedbacks = "api/feedbacks";
    public const string Orders = "api/orders";
    public const string Packages = "api/packages";
    public const string Courses = "api/courses";
    public const string Providers = "api/providers";
    public const string Sessions = "api/sessions";
    public const string Users = "api/users";
    public const string Students = "api/students";
    public const string Payments = "api/payments";

    public const string SortFieldDefault = "CreatedDate";
    public const int PageNumberDefault = 1;
    public const int PageSizeDefault = 10;
    public const SortOrder SortOrderDefault = SortOrder.Descending;
    public static readonly DateTime ExpirationLogin = DateTime.Now.AddHours(1);
}