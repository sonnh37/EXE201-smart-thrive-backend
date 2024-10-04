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

    #region Url api
    private const string BaseApi = "api/";

    public const string Categories = $"{BaseApi}categories";

    public const string Subjects = $"{BaseApi}subjects";

    public const string Vouchers = $"{BaseApi}vouchers";

    public const string Blogs = $"{BaseApi}blogs";

    public const string Modules = $"{BaseApi}modules";

    public const string Feedbacks = $"{BaseApi}feedbacks";

    public const string Orders = $"{BaseApi}orders";

    public const string Packages = $"{BaseApi}packages";

    public const string Courses = $"{BaseApi}courses";

    public const string Providers = $"{BaseApi}providers";

    public const string Sessions = $"{BaseApi}sessions";

    public const string Users = $"{BaseApi}users";

    public const string Students = $"{BaseApi}students";

    public const string Payments = $"{BaseApi}payments";

    public const string Assistants = $"{BaseApi}assistants";


    public const string StudentXPackage = $"{BaseApi}studentxpackages";

    public const string PackageXCourse = $"{BaseApi}packagexcourses";

    public const string SortFieldDefault = "CreatedDate";
    #endregion

    #region Default get query
    public const int PageNumberDefault = 1;

    public const bool IsPagination = false;

    public const int PageSizeDefault = 10;

    public const SortOrder SortOrderDefault = SortOrder.Descending;
    #endregion

    public static readonly DateTime ExpirationLogin = DateTime.Now.AddHours(1);
}