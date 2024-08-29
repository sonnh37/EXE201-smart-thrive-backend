// using EXE201.SmartThrive.Domain.Entities;
//
// namespace EXE201.SmartThrive.Data;
// using System;
// using System.Linq;
// using Bogus; // Using Bogus for Faker.NET
// using Microsoft.EntityFrameworkCore;
//
// public class DummyData
// {
//     public static void SeedDatabase(DbContext context)
//     {
//         // Seed Users
//         if (!context.Set<User>().Any())
//         {
//             var userFaker = new Faker<User>()
//                 .RuleFor(u => u.Id, f => Guid.NewGuid())
//                 .RuleFor(u => u.Username, f => f.Internet.UserName())
//                 .RuleFor(u => u.Password, f => f.Internet.Password())
//                 .RuleFor(u => u.FirstName, f => f.Name.FirstName())
//                 .RuleFor(u => u.LastName, f => f.Name.LastName())
//                 .RuleFor(u => u.ImageUrl, f => f.Internet.Avatar())
//                 .RuleFor(u => u.Email, f => f.Internet.Email())
//                 .RuleFor(u => u.Dob, f => f.Date.Past(30))
//                 .RuleFor(u => u.Address, f => f.Address.FullAddress())
//                 .RuleFor(u => u.Gender, f => f.PickRandom(new[] { "Male", "Female" }))
//                 .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
//                 .RuleFor(u => u.Status, f => f.PickRandom(new[] { "Active", "Inactive" }))
//                 .RuleFor(u => u.RoleName, f => f.PickRandom(new[] { "Admin", "User" }))
//                 .RuleFor(u => u.CreatedBy, f => "Seeder")
//                 .RuleFor(u => u.CreatedDate, f => f.Date.Past(2))
//                 .RuleFor(u => u.IsDeleted, f => false);
//
//             var users = userFaker.Generate(10); // Generate 10 users
//             context.Set<User>().AddRange(users);
//             context.SaveChanges();
//         }
//
//         // Seed Categories
//         if (!context.Set<Category>().Any())
//         {
//             var categoryFaker = new Faker<Category>()
//                 .RuleFor(c => c.Id, f => Guid.NewGuid())
//                 .RuleFor(c => c.Name, f => f.Commerce.Department())
//                 .RuleFor(c => c.CreatedBy, f => "Seeder")
//                 .RuleFor(c => c.CreatedDate, f => f.Date.Past(2))
//                 .RuleFor(c => c.IsDeleted, f => false);
//
//             var categories = categoryFaker.Generate(5); // Generate 5 categories
//             context.Set<Category>().AddRange(categories);
//             context.SaveChanges();
//         }
//
//         // Seed Subjects
//         if (!context.Set<Subject>().Any())
//         {
//             var subjects = context.Set<Category>().Select(c => c.Id).ToList();
//             var subjectFaker = new Faker<Subject>()
//                 .RuleFor(s => s.Id, f => Guid.NewGuid())
//                 .RuleFor(s => s.Name, f => f.Commerce.ProductName())
//                 .RuleFor(s => s.CategoryId, f => f.PickRandom(subjects))
//                 .RuleFor(s => s.CreatedBy, f => "Seeder")
//                 .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
//                 .RuleFor(s => s.IsDeleted, f => false);
//
//             var subjectsList = subjectFaker.Generate(10); // Generate 10 subjects
//             context.Set<Subject>().AddRange(subjectsList);
//             context.SaveChanges();
//         }
//
//         // Seed Providers
//         if (!context.Set<Provider>().Any())
//         {
//             var userIds = context.Set<User>().Select(u => u.Id).ToList();
//             var providerFaker = new Faker<Provider>()
//                 .RuleFor(p => p.Id, f => Guid.NewGuid())
//                 .RuleFor(p => p.UserId, f => f.PickRandom(userIds))
//                 .RuleFor(p => p.CompanyName, f => f.Company.CompanyName())
//                 .RuleFor(p => p.Website, f => f.Internet.Url())
//                 .RuleFor(p => p.CreatedBy, f => "Seeder")
//                 .RuleFor(p => p.CreatedDate, f => f.Date.Past(2))
//                 .RuleFor(p => p.IsDeleted, f => false);
//
//             var providers = providerFaker.Generate(5); // Generate 5 providers
//             context.Set<Provider>().AddRange(providers);
//             context.SaveChanges();
//         }
//
//         // Similarly, create and seed the remaining tables.
//     }
// }
