using EXE201.SmartThrive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EXE201.SmartThrive.Data.Context;

public class STDbContext : BaseDbContext
{
    public STDbContext(DbContextOptions<STDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e =>
        {
            e.ToTable("User");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

            e.HasOne(e => e.Provider)
                .WithOne(p => p.User)
                .HasForeignKey<Provider>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            // Configuring the relationship between User and Blogs (one-to-many)
            e.HasMany(e => e.Blogs)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring the relationship between User and Students (one-to-many)
            e.HasMany(e => e.Students)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Provider>(e =>
        {
            e.ToTable("Provider");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

            e.HasMany(e => e.Courses)
                .WithOne(s => s.Provider)
                .HasForeignKey(s => s.ProviderId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(e => e.User)
                .WithOne(p => p.Provider)
                .HasForeignKey<Provider>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Student>(e =>
        {
            e.ToTable("Student");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

            e.HasOne(x => x.User)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(e => e.Feedback)
                .WithOne(p => p.Student)
                .HasForeignKey<Feedback>(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasMany(e => e.StudentXPackages)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Category>(e =>
        {
            e.ToTable("Category");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

            e.HasMany(e => e.Subjects)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Subject>(e =>
        {
            e.ToTable("Subject");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

            e.HasOne(x => x.Category)
                .WithMany(x => x.Subjects)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Course>(e =>
        {
            e.ToTable("Course");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");
            e.Property(x => x.Price).HasColumnType("decimal(18,2)");

            e.HasOne(x => x.Subject)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Provider)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);
            e.HasMany(e => e.Modules)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasMany(e => e.Feedbacks)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasMany(e => e.PackageXCourses)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Session>(e =>
        {
            e.ToTable("Session");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

            e.HasOne(x => x.Module)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.ModuleId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(s => s.SessionOffline)
                .WithOne(so => so.Session)
                .HasForeignKey<SessionOffline>(so => so.Id);
            e.HasOne(s => s.SessionMeeting)
                .WithOne(sm => sm.Session)
                .HasForeignKey<SessionMeeting>(sm => sm.Id);
            e.HasOne(s => s.SessionSelfLearn)
                .WithOne(ss => ss.Session)
                .HasForeignKey<SessionSelfLearn>(ss => ss.Id);
        });

        modelBuilder.Entity<Package>(e =>
        {
            e.ToTable("Package");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");
            e.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");

            e.HasOne(x => x.Order)
                .WithOne(x => x.Package)
                .HasForeignKey<Order>(x => x.PackageId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasMany(e => e.PackageXCourses)
                .WithOne(s => s.Package)
                .HasForeignKey(s => s.PackageId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasMany(e => e.StudentXPackages)
                .WithOne(s => s.Package)
                .HasForeignKey(s => s.PackageId)
                .OnDelete(DeleteBehavior.Cascade);
        });


        modelBuilder.Entity<PackageXCourse>(e =>
        {
            e.ToTable("CourseXPackage");
            e.HasKey(cp => cp.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

            e.HasOne(cp => cp.Course)
                .WithMany(c => c.PackageXCourses)
                .HasForeignKey(cp => cp.CourseId)
                .OnDelete(DeleteBehavior.Restrict); // Specify NO ACTION on delete;
            e.HasOne(cp => cp.Package)
                .WithMany(p => p.PackageXCourses)
                .HasForeignKey(cp => cp.PackageId)
                .OnDelete(DeleteBehavior.Restrict); // Specify NO ACTION on delete;
        });

        modelBuilder.Entity<Order>(e =>
        {
            e.ToTable("Order");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");
            e.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");

            e.HasOne(x => x.Package)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.PackageId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Voucher)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.VoucherId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasMany(e => e.OrderDetails)
                .WithOne(s => s.Order)
                .HasForeignKey(s => s.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // new
        modelBuilder.Entity<StudentXPackage>(e =>
        {
            e.ToTable("StudentXPackage");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            
            e.HasOne(x => x.Student)
                .WithMany(x => x.StudentXPackages)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.Package)
                .WithMany(x => x.StudentXPackages)
                .HasForeignKey(x => x.PackageId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<OrderDetail>(e =>
        {
            e.ToTable("OrderDetail");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            e.Property(x => x.Price).HasColumnType("decimal(18,2)");
            e.Property(x => x.PriceDiscount).HasColumnType("decimal(18,2)");
            
            e.HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<SessionMeeting>(e =>
        {
            e.ToTable("SessionMeeting");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        });

        modelBuilder.Entity<SessionOffline>(e =>
        {
            e.ToTable("SessionOffline");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        });

        modelBuilder.Entity<SessionSelfLearn>(e =>
        {
            e.ToTable("SessionSelfLearn");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        });

        modelBuilder.Entity<Voucher>(e =>
        {
            e.ToTable("Voucher");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            
            e.HasOne(x => x.Order)
                .WithOne(x => x.Voucher)
                .HasForeignKey<Order>(x => x.VoucherId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Blog>(e =>
        {
            e.ToTable("Blog");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            
            e.HasOne(x => x.User)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Assisant>(e =>
        {
            e.ToTable("Assisant");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        });

        // Configure DayInWeek entity
        modelBuilder.Entity<DayInWeek>(e =>
        {
            e.ToTable("DayInWeek");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            
            e.HasOne(x => x.Course)
                .WithOne(x => x.DayInWeek)
                .HasForeignKey<DayInWeek>(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure Feedback entity
        modelBuilder.Entity<Feedback>(e =>
        {
            e.ToTable("Feedback");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            
            e.HasOne(x => x.Student)
                .WithOne(x => x.Feedback)
                .HasForeignKey<Feedback>(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Course)
                .WithMany(x => x.Feedbacks)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure Module entity
        modelBuilder.Entity<Module>(e =>
        {
            e.ToTable("Module");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            
            e.HasOne(x => x.Course)
                .WithMany(x => x.Modules)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            
            e.HasMany(e => e.Sessions)
                .WithOne(s => s.Module)
                .HasForeignKey(s => s.ModuleId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    #region Config

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(GetConnectionString());
    }

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        var strConn = /*config["ConnectionStrings:DB"]*/ config.GetConnectionString("SmartThrive");

        return strConn;
    }

    #endregion

    #region Dbset

    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Category> Categories { get; set; } = null!;
    public virtual DbSet<Course> Courses { get; set; } = null!;
    public virtual DbSet<Order> Orders { get; set; } = null!;
    public virtual DbSet<Package> Packages { get; set; } = null!;
    public virtual DbSet<Provider> Provider { get; set; } = null!;
    public virtual DbSet<Session> Sessions { get; set; } = null!;
    public virtual DbSet<Subject> Subjects { get; set; } = null!;
    public virtual DbSet<Student> Students { get; set; } = null!;
    public virtual DbSet<PackageXCourse> CourseXPackages { get; set; } = null!;

    public virtual DbSet<StudentXPackage> StudentXPackages { get; set; } = null!;
    public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    public virtual DbSet<SessionMeeting> SessionMeetings { get; set; } = null!;
    public virtual DbSet<SessionOffline> SessionOfflines { get; set; } = null!;
    public virtual DbSet<SessionSelfLearn> SessionSelfLearns { get; set; } = null!;
    public virtual DbSet<Voucher> Vouchers { get; set; } = null!;
    public virtual DbSet<Blog> Blogs { get; set; } = null!;
    public virtual DbSet<Assisant> Assisants { get; set; } = null!;
    public virtual DbSet<DayInWeek> DayInWeeks { get; set; } = null!;
    public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
    public virtual DbSet<Module> Modules { get; set; } = null!;

    #endregion
}