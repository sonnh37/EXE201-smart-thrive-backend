using Bogus;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.Data;

// Using Bogus for Faker.NET

public static class DummyData
{
    public static void SeedDatabase(DbContext context)
    {
        GenerateAssistants(context, 20);
        GenerateCategories(context, 10);
        GenerateSubjects(context, 20);
        GenerateUsers(context, 20);
        GenerateBlogs(context, 20);
        GenerateProviders(context, 20);
        GenerateAddresses(context, 20);
        GenerateCourses(context, 20);
        GenerateDayInWeeks(context, 20);
        GenerateModules(context, 5);
        GenerateStudents(context, 20);
        GenerateFeedbacks(context, 20);
        GeneratePackages(context, 20);
        GeneratePackageXCourses(context, 20);
        GenerateStudentXPackages(context, 20);
        GenerateVouchers(context, 20);
        GenerateOrders(context, 20);
    }

    public static void GenerateAssistants(DbContext context, int count)
    {
        if (!context.Set<Assistant>().Any())
        {
            var assistantFaker = new Faker<Assistant>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.FullName, f => f.Name.FullName()) // Tạo tên đầy đủ
                .RuleFor(a => a.Phone, f => f.Phone.PhoneNumber()) // Tạo số điện thoại
                .RuleFor(a => a.Email, f => f.Internet.Email()) // Tạo email
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);
            var assistants = assistantFaker.Generate(count); // Tạo dữ liệu Assistant

            context.Set<Assistant>().AddRange(assistants); // Thêm vào cơ sở dữ liệu
            context.SaveChanges(); // Lưu thay đổi
        }
    }

    public static void GenerateBlogs(DbContext context, int count)
    {
        if (!context.Set<Blog>().Any())
        {
            // Lấy danh sách các User Id đã tồn tại
            var userIds = context.Set<User>().Select(u => u.Id).ToList();

            var blogFaker = new Faker<Blog>()
                .RuleFor(b => b.Id, f => Guid.NewGuid())
                .RuleFor(b => b.UserId, f => f.PickRandom(userIds)) // Chọn ngẫu nhiên UserId
                .RuleFor(b => b.Title, f => f.Lorem.Sentence()) // Tạo tiêu đề blog
                .RuleFor(b => b.Description, f => f.Lorem.Paragraph()) // Tạo mô tả blog
                .RuleFor(b => b.IsActive, f => f.Random.Bool()) // Chọn ngẫu nhiên trạng thái hoạt động
                .RuleFor(b => b.BackgroundImage, f => f.Image.PicsumUrl()) // Tạo URL cho hình nền
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);
            var blogs = blogFaker.Generate(count); // Tạo dữ liệu Blog

            context.Set<Blog>().AddRange(blogs); // Thêm vào cơ sở dữ liệu
            context.SaveChanges(); // Lưu thay đổi
        }
    }

    public static void GenerateDayInWeeks(DbContext context, int count)
    {
        if (!context.Set<DayInWeek>().Any())
        {
            // Lấy danh sách các Course Id đã tồn tại
            var courseIds = context.Set<Course>().Select(c => c.Id).ToList();

            var dayInWeekFaker = new Faker<DayInWeek>()
                .RuleFor(d => d.Id, f => Guid.NewGuid())
                .RuleFor(d => d.CourseId, f => f.PickRandom(courseIds)) // Chọn ngẫu nhiên CourseId
                .RuleFor(d => d.Monday, f => f.Random.Bool()) // Chọn ngẫu nhiên giá trị cho các ngày trong tuần
                .RuleFor(d => d.Tuesday, f => f.Random.Bool())
                .RuleFor(d => d.Wednesday, f => f.Random.Bool())
                .RuleFor(d => d.Thursday, f => f.Random.Bool())
                .RuleFor(d => d.Friday, f => f.Random.Bool())
                .RuleFor(d => d.Saturday, f => f.Random.Bool())
                .RuleFor(d => d.Sunday, f => f.Random.Bool())
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);

            var daysInWeek = dayInWeekFaker.Generate(count); // Tạo dữ liệu DayInWeek

            context.Set<DayInWeek>().AddRange(daysInWeek); // Thêm vào cơ sở dữ liệu
            context.SaveChanges(); // Lưu thay đổi
        }
    }

    public static void GenerateFeedbacks(DbContext context, int count)
    {
        if (!context.Set<Feedback>().Any())
        {
            // Lấy danh sách các Student Id và Course Id đã tồn tại
            var studentIds = context.Set<Student>().Select(s => s.Id).ToList();
            var courseIds = context.Set<Course>().Select(c => c.Id).ToList();

            var feedbackFaker = new Faker<Feedback>()
                .RuleFor(f => f.Id, f => Guid.NewGuid())
                .RuleFor(f => f.StudentId, f => f.PickRandom(studentIds)) // Chọn ngẫu nhiên StudentId
                .RuleFor(f => f.CourseId, f => f.PickRandom(courseIds)) // Chọn ngẫu nhiên CourseId
                .RuleFor(f => f.Description, f => f.Lorem.Sentence()) // Tạo mô tả cho feedback
                .RuleFor(f => f.Rating, f => f.Random.Int(1, 5))
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);
            // Tạo rating từ 1 đến 5

            var feedbacks = feedbackFaker.Generate(count); // Tạo dữ liệu feedback

            context.Set<Feedback>().AddRange(feedbacks); // Thêm vào cơ sở dữ liệu
            context.SaveChanges(); // Lưu thay đổi
        }
    }

    public static void GenerateModules(DbContext context, int count)
    {
        if (!context.Set<Module>().Any())
        {
            var courses = context.Set<Course>().ToList();
            foreach (var course in courses)
            {
                var moduleNumber = 1; // Khởi tạo ModuleNumber cho mỗi Course

                var moduleFaker = new Faker<Module>()
                    .RuleFor(m => m.Id, f => Guid.NewGuid())
                    .RuleFor(m => m.CourseId, f => course.Id)
                    .RuleFor(m => m.Name, f => f.Commerce.Department()) // Tạo tên cho module
                    .RuleFor(m => m.ModuleNumber, f => moduleNumber++) // ModuleNumber tăng dần
                    .RuleFor(m => m.Description, f => f.Lorem.Paragraph()) // Tạo mô tả cho module
                    .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                    .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                    .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                    .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                    .RuleFor(s => s.IsDeleted, f => false);

                var modules = moduleFaker.Generate(count); // Tạo count module cho mỗi course

                context.Set<Module>().AddRange(modules); // Thêm vào cơ sở dữ liệu
                context.SaveChanges(); // Lưu thay đổi

                // Đã có 10 module trong 1 khóa học
                // Check khóa học là offline hay online

                if (course.Type == CourseType.Offline) GenerateSessionOfflines(context, count);

                if (course.Type == CourseType.Online) GenerateSessionOnlines(context, count);
            }
        }
    }

    public static void GenerateSessionOfflines(DbContext context, int count)
    {
        // Clear the change tracker to avoid tracking conflicts
        context.ChangeTracker.Clear();

        var modules = context.Set<Module>()
            .Include(n => n.Sessions)
            .Where(m => m.Sessions != null && !m.Sessions.Any()) // Lọc các module chưa có session
            .ToList();

        foreach (var module in modules)
        {
            var sessionNumber = 1;

            // Create Session data
            var sessionFaker = new Faker<Session>()
                .RuleFor(s => s.Id, f => Guid.NewGuid())
                .RuleFor(s => s.ModuleId, f => module.Id) // Dùng cùng một ModuleId
                .RuleFor(s => s.Title, f => f.Lorem.Sentence())
                .RuleFor(s => s.SessionNumber, f => sessionNumber++)
                .RuleFor(s => s.Document, f => f.Lorem.Word())
                .RuleFor(s => s.SessionType, f => SessionType.Offline)
                .RuleFor(s => s.Description, f => f.Lorem.Paragraph())
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);

            var sessions = sessionFaker.Generate(count);
            context.Set<Session>().AddRange(sessions);
            context.SaveChanges();

            // Get the list of newly added session IDs
            var sessionIds = sessions.Select(s => s.Id).ToList();

            // Clear the change tracker before adding other entities
            context.ChangeTracker.Clear();

            // Create SessionOffline data
            var sessionOfflineFaker = new Faker<SessionOffline>()
                .RuleFor(s => s.Id, f => Guid.NewGuid())
                .RuleFor(s => s.SessionId, f => f.PickRandom(sessionIds)) // Pick a random SessionId
                .RuleFor(s => s.Location, f => f.Address.City())
                .RuleFor(s => s.Date, f => f.Date.Future(30))
                .RuleFor(s => s.Duration, f => f.Random.Int(30, 180))
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);

            var sessionOfflineList = sessionOfflineFaker.Generate(count);

            // Ensure that each SessionOffline entity has a unique SessionId
            var usedSessionIds = new HashSet<Guid>();

            var uniqueSessionOfflineList = sessionOfflineList
                .Where(so => so.SessionId.HasValue && usedSessionIds.Add(so.SessionId.Value))
                .ToList();

            context.Set<SessionOffline>().AddRange(uniqueSessionOfflineList);
            context.SaveChanges();
        }
    }

    public static void GenerateSessionOnlines(DbContext context, int count)
    {
        // Clear the change tracker to avoid tracking conflicts
        context.ChangeTracker.Clear();

        var modules = context.Set<Module>()
            .Include(n => n.Sessions)
            .Where(m => m.Sessions != null && !m.Sessions.Any()) // Lọc các module chưa có session
            .ToList();

        foreach (var module in modules)
        {
            var sessionNumber = 1;

            // Create Session data
            var sessionFaker = new Faker<Session>()
                .RuleFor(s => s.Id, f => Guid.NewGuid())
                .RuleFor(s => s.ModuleId, f => module.Id) // Dùng cùng một ModuleId
                .RuleFor(s => s.Title, f => f.Lorem.Sentence())
                .RuleFor(s => s.SessionNumber, f => sessionNumber++)
                .RuleFor(s => s.Document, f => f.Lorem.Word())
                .RuleFor(s => s.SessionType, f => f.PickRandom(SessionType.Meeting, SessionType.SelfLearn))
                .RuleFor(s => s.Description, f => f.Lorem.Paragraph())
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);

            var sessions = sessionFaker.Generate(count);
            context.Set<Session>().AddRange(sessions);
            context.SaveChanges();

            foreach (var session in sessions)
            {
                if (session.SessionType == SessionType.Meeting) GenerateSessionMeetingOnlines(context, count, session);

                if (session.SessionType == SessionType.SelfLearn)
                    GenerateSessionSelfLearnOnlines(context, count, session);
            }
        }
    }

    private static void GenerateSessionMeetingOnlines(DbContext context, int count, Session session)
    {
        context.ChangeTracker.Clear();
        var sessionMeetingFaker = new Faker<SessionMeeting>()
            .RuleFor(s => s.Id, f => Guid.NewGuid())
            .RuleFor(s => s.SessionId, f => session.Id)
            .RuleFor(s => s.Host, f => f.Name.FullName())
            .RuleFor(s => s.Date, f => f.Date.Future(30))
            .RuleFor(s => s.MeetingUrl, f => f.Internet.Url())
            .RuleFor(s => s.MeetingPlatform, f => f.Company.Bs())
            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
            .RuleFor(s => s.IsDeleted, f => false);

        var sessionMeetings = sessionMeetingFaker.Generate(count);

        var usedSessionIds = new HashSet<Guid>();

        var uniqueSessionMeetingList = sessionMeetings
            .Where(so => so.SessionId.HasValue && usedSessionIds.Add(so.SessionId.Value))
            .ToList();

        context.Set<SessionMeeting>().AddRange(uniqueSessionMeetingList);
        context.SaveChanges();
    }


    private static void GenerateSessionSelfLearnOnlines(DbContext context, int count, Session session)
    {
        context.ChangeTracker.Clear();
        var sessionNumber = 1;
        // Create SessionOffline data
        var sessionMeetingFaker = new Faker<SessionSelfLearn>()
            .RuleFor(s => s.Id, f => Guid.NewGuid())
            .RuleFor(s => s.SessionId, f => session.Id)
            .RuleFor(s => s.SessionNumber, f => sessionNumber++)
            .RuleFor(s => s.VideoUrl, f => f.Internet.Url())
            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
            .RuleFor(s => s.IsDeleted, f => false);

        var sessionSelfLearnOnlineList = sessionMeetingFaker.Generate(count);

        var usedSessionIds = new HashSet<Guid>();

        var uniqueSessionMeetingList = sessionSelfLearnOnlineList
            .Where(so => so.SessionId.HasValue && usedSessionIds.Add(so.SessionId.Value))
            .ToList();

        context.Set<SessionSelfLearn>().AddRange(uniqueSessionMeetingList);
        context.SaveChanges();
    }

    public static void GenerateVouchers(DbContext context, int count)
    {
        if (!context.Set<Voucher>().Any())
        {
            var voucherFaker = new Faker<Voucher>()
                .RuleFor(v => v.Id, f => Guid.NewGuid())
                .RuleFor(v => v.VoucherType, f => f.PickRandom<VoucherType>())
                .RuleFor(v => v.Name, f => f.Commerce.ProductName())
                .RuleFor(v => v.Code, f => f.Random.AlphaNumeric(10)) // Ví dụ: mã voucher có 10 ký tự
                .RuleFor(v => v.Value, f => f.Random.Int(1, 1000)) // Giá trị voucher từ 1 đến 1000
                .RuleFor(v => v.Condition, f => f.Random.Int(0, 100)) // Điều kiện voucher từ 0 đến 100
                .RuleFor(v => v.Status, f => f.PickRandom<VoucherStatus>())
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);

            var vouchers = voucherFaker.Generate(count); // Tạo dữ liệu giả cho số lượng vouchers mong muốn

            context.Set<Voucher>().AddRange(vouchers);
            context.SaveChanges();
        }
    }

    public static void GenerateOrders(DbContext context, int count)
    {
        // Kiểm tra xem có dữ liệu trong bảng Order chưa
        if (!context.Set<Order>().Any())
        {
            // Lấy danh sách PackageIds và VoucherIds từ các bảng tương ứng
            var packageIds = context.Set<Package>().Select(p => p.Id).ToList();
            var voucherIds = context.Set<Voucher>().Select(v => (Guid?)v.Id).ToList();

            // Nếu danh sách packageIds rỗng, không thể tạo Order
            if (!packageIds.Any()) throw new InvalidOperationException("No packages available to create Orders.");

            var faker = new Faker<Order>()
                .RuleFor(o => o.Id, f => Guid.NewGuid())
                .RuleFor(o => o.PackageId, f => f.PickRandom(packageIds)) // Liên kết với một gói ngẫu nhiên
                .RuleFor(o => o.VoucherId,
                    f => f.PickRandom(voucherIds.Concat(new[] { (Guid?)null }))) // Có thể không có voucher
                .RuleFor(o => o.PaymentMethod, f => f.PickRandom<PaymentMethod>())
                .RuleFor(o => o.TotalPrice, f => f.Finance.Amount(100)) // Số tiền từ 100 đến 1000
                .RuleFor(o => o.Description, f => f.Lorem.Sentence())
                .RuleFor(o => o.Status, f => f.PickRandom<OrderStatus>())
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);

            var orders = faker.Generate(count); // Tạo các bản ghi Order

            context.Set<Order>().AddRange(orders);
            context.SaveChanges();
        }
    }

    public static void GeneratePackageXCourses(DbContext context, int count)
    {
        // Kiểm tra xem có dữ liệu trong bảng PackageXCourse chưa
        if (!context.Set<PackageXCourse>().Any())
        {
            // Lấy danh sách CourseIds và PackageIds từ các bảng tương ứng
            var courseIds = context.Set<Course>().Select(c => c.Id).ToList();
            var packageIds = context.Set<Package>().Select(p => p.Id).ToList();

            // Nếu danh sách courseIds hoặc packageIds rỗng, không thể tạo PackageXCourse
            if (!courseIds.Any() || !packageIds.Any())
                throw new InvalidOperationException("No courses or packages available to create PackageXCourses.");

            var faker = new Faker<PackageXCourse>()
                .RuleFor(pxc => pxc.Id, f => Guid.NewGuid())
                .RuleFor(pxc => pxc.CourseId, f => f.PickRandom(courseIds)) // Liên kết với một khóa học ngẫu nhiên
                .RuleFor(pxc => pxc.PackageId, f => f.PickRandom(packageIds)) // Liên kết với một gói ngẫu nhiên
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);
            var packageXCourses = faker.Generate(count); // Tạo các bản ghi PackageXCourse

            context.Set<PackageXCourse>().AddRange(packageXCourses);
            context.SaveChanges();
        }
    }

    public static void GenerateStudentXPackages(DbContext context, int count)
    {
        // Kiểm tra xem có dữ liệu trong bảng StudentXPackage chưa
        if (!context.Set<StudentXPackage>().Any())
        {
            // Lấy danh sách StudentIds và PackageIds từ các bảng tương ứng
            var studentIds = context.Set<Student>().Select(s => s.Id).ToList();
            var packageIds = context.Set<Package>().Select(p => p.Id).ToList();

            // Nếu danh sách studentIds hoặc packageIds rỗng, không thể tạo StudentXPackage
            if (!studentIds.Any() || !packageIds.Any())
                throw new InvalidOperationException("No students or packages available to create StudentXPackages.");

            var faker = new Faker<StudentXPackage>()
                .RuleFor(sxp => sxp.Id, f => Guid.NewGuid())
                .RuleFor(sxp => sxp.StudentId, f => f.PickRandom(studentIds)) // Liên kết với một sinh viên ngẫu nhiên
                .RuleFor(sxp => sxp.PackageId, f => f.PickRandom(packageIds)) // Liên kết với một gói ngẫu nhiên
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);
            var studentXPackages = faker.Generate(count); // Tạo các bản ghi StudentXPackage

            context.Set<StudentXPackage>().AddRange(studentXPackages);
            context.SaveChanges();
        }
    }

    public static void GeneratePackages(DbContext context, int count)
    {
        // Kiểm tra xem có dữ liệu trong bảng Package chưa
        if (!context.Set<Package>().Any())
        {
            // Lấy danh sách StudentIds từ bảng Student
            var studentIds = context.Set<Student>().Select(s => s.Id).ToList();

            // Nếu danh sách studentIds rỗng, không thể tạo package
            if (!studentIds.Any())
                throw new InvalidOperationException("No students available to associate with packages.");

            var faker = new Faker<Package>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.QuantityCourse, f => f.Random.Number(1, 10)) // Number of courses in the package
                .RuleFor(p => p.TotalPrice, f => f.Finance.Amount(100)) // Total price range between 100 and 1000
                .RuleFor(p => p.IsActive, f => f.Random.Bool())
                .RuleFor(p => p.Status, f => f.PickRandom<PackageStatus>())
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);
            // Associate with a random student if available

            var packages = faker.Generate(count); // Generate packages

            context.Set<Package>().AddRange(packages);
            context.SaveChanges();
        }
    }

    public static void GenerateCourses(DbContext context, int count)
    {
        // Kiểm tra xem có dữ liệu trong bảng Course chưa
        if (!context.Set<Course>().Any())
        {
            // Lấy danh sách SubjectIds và ProviderIds từ bảng Subject và Provider
            var subjectIds = context.Set<Subject>().Select(s => s.Id).ToList();
            var providerIds = context.Set<Provider>().Select(p => p.Id).ToList();

            // Nếu danh sách subjectIds hoặc providerIds rỗng, không thể tạo course
            if (!subjectIds.Any() || !providerIds.Any())
                throw new InvalidOperationException("No subjects or providers available to associate with courses.");

            var faker = new Faker<Course>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.SubjectId, f => f.PickRandom(subjectIds))
                .RuleFor(c => c.ProviderId, f => f.PickRandom(providerIds))
                .RuleFor(c => c.TeacherName, f => f.Name.FullName())
                .RuleFor(c => c.Type,
                    f => f.PickRandom<CourseType>())
                .RuleFor(c => c.Name, f => f.Commerce.ProductName())
                .RuleFor(c => c.Code, f => f.Commerce.Ean8())
                .RuleFor(c => c.Name, f => f.Commerce.ProductName())
                .RuleFor(c => c.Description, f => f.Lorem.Paragraph())
                .RuleFor(c => c.BackgroundImage, f => f.Image.LoremFlickrUrl())
                .RuleFor(c => c.Price, f => f.Finance.Amount(50, 500)) // Price range between 50 and 500
                .RuleFor(c => c.SoldCourses, f => f.Random.Number(0, 100))
                .RuleFor(c => c.TotalSlots, f => f.Random.Number(10, 100))
                .RuleFor(c => c.TotalSessions, f => f.Random.Number(1, 20))
                .RuleFor(c => c.StartTime, f => f.Date.Recent().TimeOfDay) // Ensure this is within the valid range
                .RuleFor(c => c.EndTime, f => f.Date.Future().TimeOfDay) // End time is one hour after start time
                .RuleFor(c => c.Status, f => f.PickRandom<CourseStatus>())
                .RuleFor(c => c.IsActive, f => f.Random.Bool())
                .RuleFor(c => c.StartDate, f => f.Date.Recent()) // Future date for start
                .RuleFor(c => c.EndDate, f => f.Date.Future(2))
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);
            // End date should be after start date

            var courses = faker.Generate(count); // Generate courses

            context.Set<Course>().AddRange(courses);
            context.SaveChanges();
        }
    }

    public static void GenerateStudents(DbContext context, int count)
    {
        // Kiểm tra xem có dữ liệu trong bảng Student chưa
        if (!context.Set<Student>().Any())
        {
            // Lấy danh sách UserIds từ bảng User
            var userIds = context.Set<User>().Select(u => u.Id).ToList();

            // Nếu danh sách userIds rỗng, không thể tạo student
            if (!userIds.Any()) throw new InvalidOperationException("No users available to associate with students.");

            var faker = new Faker<Student>()
                .RuleFor(s => s.Id, f => Guid.NewGuid())
                .RuleFor(s => s.UserId, f => f.PickRandom(userIds))
                .RuleFor(s => s.StudentName, f => f.Name.FullName())
                .RuleFor(s => s.Gender, f => f.PickRandom<Gender>())
                .RuleFor(s => s.Dob,
                    f => f.Date.Past(20,
                        DateTime.Now.AddYears(-18))) // Date of Birth, ensuring students are at least 18
                .RuleFor(b => b.ImageAvatar, f => f.Image.PicsumUrl()) // Tạo URL cho hình nền
                .RuleFor(s => s.Status, f => f.PickRandom<UserStatus>())
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);

            var students = faker.Generate(count); // Generate students

            context.Set<Student>().AddRange(students);
            context.SaveChanges();
        }
    }

    public static void GenerateAddresses(DbContext context, int count)
    {
        if (!context.Set<Address>().Any())
        {
            // Lấy danh sách các Id của Providers từ cơ sở dữ liệu
            var providerIds = context.Set<Provider>().Select(p => p.Id).ToList();

            // Khởi tạo Faker cho Address
            var addressFaker = new Faker<Address>()
                .RuleFor(a => a.Id, f => Guid.NewGuid()) // Tạo Id mới duy nhất cho Address
                .RuleFor(a => a.ProviderId,
                    f => f.PickRandom(providerIds)) // Chọn ProviderId ngẫu nhiên từ danh sách providerIds
                .RuleFor(a => a.City, f => f.Address.City()) // Tạo tên thành phố giả
                .RuleFor(a => a.District, f => f.Address.County()) // Tạo tên quận/huyện giả
                .RuleFor(a => a.Town, f => f.Address.CityPrefix()) // Tạo tên xã/phường/thị trấn giả
                .RuleFor(a => a.Street, f => f.Address.StreetName()) // Tạo tên đường giả
                .RuleFor(a => a.BuildingNumber, f => f.Address.BuildingNumber()) // Tạo số nhà giả
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);

            // Tạo danh sách các Address giả
            var addresses = addressFaker.Generate(count); // Generate 'count' addresses

            // Thêm các address vào DbContext và lưu thay đổi
            context.Set<Address>().AddRange(addresses);
            context.SaveChanges();
        }
    }

    public static void GenerateSubjects(DbContext context, int count)
    {
        // Kiểm tra xem bảng Subject có dữ liệu chưa
        if (!context.Set<Subject>().Any())
        {
            // Lấy danh sách ID của các Category
            var categoryIds = context.Set<Category>().Select(c => c.Id).ToList();

            // Khởi tạo Faker cho Subject
            var subjectFaker = new Faker<Subject>()
                .RuleFor(s => s.Id, f => Guid.NewGuid())
                .RuleFor(s => s.Name, f => f.Commerce.ProductName())
                .RuleFor(s => s.CategoryId, f => f.PickRandom(categoryIds)) // Chọn CategoryId từ danh sách có sẵn
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);

            // Tạo danh sách các subject giả
            var subjectsList = subjectFaker.Generate(count); // Generate 'count' subjects

            // Thêm các subject vào DbContext và lưu thay đổi
            context.Set<Subject>().AddRange(subjectsList);
            context.SaveChanges();
        }
    }

    public static void GenerateCategories(DbContext context, int count)
    {
        // Kiểm tra xem bảng Category có dữ liệu chưa
        if (!context.Set<Category>().Any())
        {
            // Khởi tạo Faker cho Category
            var categoryFaker = new Faker<Category>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Commerce.Department()) // Tạo tên danh mục giả
                .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com") // Thay đổi nếu cần
                .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                .RuleFor(c => c.IsDeleted, f => false); // Thiết lập trạng thái xóa

            // Tạo danh sách các category giả
            var categories = categoryFaker.Generate(count); // Generate 'count' categories

            // Thêm các category vào DbContext và lưu thay đổi
            context.Set<Category>().AddRange(categories);
            context.SaveChanges();
        }
    }

    public static void GenerateProviders(DbContext context, int count)
    {
        if (!context.Set<Provider>().Any())
        {
            // Fetch user IDs and emails
            var userIdAndEmails = context.Set<User>().Select(p => new { p.Id, p.Email }).ToList();

            // Generate providers
            var faker = new Faker<Provider>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.UserId, f => f.PickRandom(userIdAndEmails).Id)
                .RuleFor(p => p.CompanyName, f => f.Company.CompanyName())
                .RuleFor(p => p.Website, f => f.Internet.Url())
                .RuleFor(p => p.CreatedDate, f => f.Date.Past(2))
                .RuleFor(p => p.UpdatedDate, f => f.Date.Recent())
                .RuleFor(p => p.CreatedBy, f => "tsql@gmail.com")
                .RuleFor(p => p.UpdatedBy, f => "tsql@gmail.com")
                .RuleFor(p => p.IsDeleted, f => false);

            var providers = faker.Generate(count);

            context.Set<Provider>().AddRange(providers);
            context.SaveChanges();
        }
    }

    public static void GenerateUsers(DbContext context, int count)
    {
        if (!context.Set<User>().Any())
        {
            var userFaker = new Faker<User>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.ImageUrl, f => f.Internet.Avatar())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Dob, f => f.Date.Past(30))
                .RuleFor(u => u.Address, f => f.Address.FullAddress())
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.Status, f => f.PickRandom<UserStatus>())
                .RuleFor(u => u.Role, f => f.PickRandom<Role>())
                .RuleFor(u => u.CreatedDate, f => f.Date.Past(2))
                .RuleFor(u => u.UpdatedDate, f => f.Date.Recent())
                .RuleFor(u => u.IsDeleted, f => false);

            // Generate users
            var users = userFaker.Generate(count);

            // Pick a common email
            var commonUserEmail = users.Count > 0 ? users.First().Email : null;

            // Set CreatedBy and UpdatedBy to the common email
            foreach (var user in users)
            {
                user.CreatedBy = commonUserEmail;
                user.UpdatedBy = commonUserEmail;
            }

            context.Set<User>().AddRange(users);
            context.SaveChanges();
        }
    }
}