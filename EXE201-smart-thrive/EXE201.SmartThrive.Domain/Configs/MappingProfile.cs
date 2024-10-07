using AutoMapper;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Assistant;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Blog;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Category;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Course;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Feedback;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Module;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Order;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Package;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.PackageXCourse;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Provider;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Session;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Student;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.StudentXPackage;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Subject;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.User;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Voucher;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Configs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        SubjectMapping();
        CategoryMapping();
        DayInWeekMapping();
        CourseMapping();
        StudentMapping();
        SubjectMapping();
        FeedbackMapping();
        ModuleMapping();
        VoucherMapping();
        BlogMapping();
        UserMapping();
        ProviderMapping();
        OrderMapping();
        SessionMapping();
        PackageMapping();
        PackageXCourseMapping();
        StudentXPackageMapping();
        AssistantMapping();
    }

    private void AssistantMapping()
    {
        CreateMap<Assistant, AssistantResult>().ReverseMap();
        CreateMap<Assistant, AssistantCreateCommand>().ReverseMap();
    }
    private void CourseMapping()
    {
        CreateMap<Course, CourseResult>().ReverseMap();
        CreateMap<Course, CourseCreateCommand>().ReverseMap();
        CreateMap<Course, CourseUpdateCommand>().ReverseMap();
    }

    private void CategoryMapping()
    {
        CreateMap<Category, CategoryResult>().ReverseMap();
        CreateMap<Category, CategoryCreateCommand>().ReverseMap();
        CreateMap<Category, CategoryUpdateCommand>().ReverseMap();
    }

    private void BlogMapping()
    {
        CreateMap<Blog, BlogResult>().ReverseMap();
        CreateMap<Blog, BlogCreateCommand>().ReverseMap();
        CreateMap<Blog, BlogUpdateCommand>().ReverseMap();
    }

    private void DayInWeekMapping()
    {
        CreateMap<DayInWeek, DayInWeekResult>().ReverseMap();
    }

    private void FeedbackMapping()
    {
        CreateMap<Feedback, FeedbackResult>().ReverseMap();
        CreateMap<Feedback, FeedbackCreateCommand>().ReverseMap();
        CreateMap<Feedback, FeedbackUpdateCommand>().ReverseMap();
    }

    private void ModuleMapping()
    {
        CreateMap<Module, ModuleResult>().ReverseMap();
        CreateMap<Module, ModuleCreateCommand>().ReverseMap();
        CreateMap<Module, ModuleUpdateCommand>().ReverseMap();
    }

    private void OrderMapping()
    {
        CreateMap<Order, OrderResult>().ReverseMap();
        CreateMap<Order, OrderCreateCommand>().ReverseMap();
        CreateMap<Order, OrderUpdateCommand>().ReverseMap();
    }

    private void PackageMapping()
    {
        CreateMap<Package, PackageResult>().ReverseMap();
        CreateMap<Package, PackageCreateCommand>().ReverseMap();
        CreateMap<Package, PackageUpdateCommand>().ReverseMap();
    }

    private void ProviderMapping()
    {
        CreateMap<Provider, ProviderResult>().ReverseMap();
        CreateMap<Provider, ProviderCreateCommand>().ReverseMap();
        CreateMap<Provider, ProviderUpdateCommand>().ReverseMap();
    }

    private void SessionMapping()
    {
        CreateMap<SessionModel, SessionCreateCommand>().ReverseMap();
        CreateMap<SessionModel, SessionUpdateCommand>().ReverseMap();
        CreateMap<SessionModel, Session>().ReverseMap();
        CreateMap<Session, SessionResult>().ReverseMap();
    }

    private void StudentMapping()
    {
        CreateMap<Student, StudentResult>().ReverseMap();
        CreateMap<Student, StudentCreateCommand>().ReverseMap();
        CreateMap<Student, StudentUpdateCommand>().ReverseMap();

    }

    private void SubjectMapping()
    {
        CreateMap<Subject, SubjectResult>().ReverseMap();
        CreateMap<Subject, SubjectCreateCommand>().ReverseMap();
        CreateMap<Subject, SubjectUpdateCommand>().ReverseMap();
    }

    private void UserMapping()
    {
        CreateMap<User, UserResult>().ReverseMap();
        CreateMap<User, UserLoginResult>().ReverseMap();
        CreateMap<User, UserCreateCommand>().ReverseMap();
        CreateMap<User, UserUpdateCommand>().ReverseMap();
    }

    private void VoucherMapping()
    {
        CreateMap<Voucher, VoucherResult>().ReverseMap();
        CreateMap<Voucher, VoucherCreateCommand>().ReverseMap();
        CreateMap<Voucher, VoucherUpdateCommand>().ReverseMap();
    }

    private void StudentXPackageMapping()
    {
        CreateMap<StudentXPackage, StudentXPackageResult>().ReverseMap();
        CreateMap<StudentXPackage, StudentXPackageCreateCommand>().ReverseMap();
        CreateMap<StudentXPackage, StudentXPackageUpdateCommand>().ReverseMap();


    }

    private void PackageXCourseMapping()
    {
        CreateMap<PackageXCourse, PackageXCourseResult>().ReverseMap();
        CreateMap<PackageXCourse, PackageXCourseCreateCommand>().ReverseMap();
        CreateMap<PackageXCourse, PackageXCourseUpdateCommand>().ReverseMap();
    }


}