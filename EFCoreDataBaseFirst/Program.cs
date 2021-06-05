using System;
using System.Linq;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDataBaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello EF Core!");
            LibraryContext context = new LibraryContext();
            // context.ChangeTracker.LazyLoadingEnabled = false;
            /* context.Books.Select(b => $"{b.Title} ({b.Author.Name})")
                .ToList().ForEach(Console.WriteLine); */
            /* context.Books
                // .OrderBy(b => b.Title)
                .OrderByDescending(b => b.Title)
                .Select(b => $"{b.Title} ({b.Author.Name})")
                .ToList()
                .ForEach(Console.WriteLine); */
            /* Author a = new Author() {Name = "June Four"};
            context.Authors.Add(a);
            context.Books.Add(new Book() {Title = "B4", Author = a});
            context.SaveChanges(); */
            
            /* context.Authors
                .OrderByDescending(a => a.Books.Count)
                .ThenByDescending(a => a.Name)
                .Take(3)
                .Select(a => $"{a.Name} ({a.Books.Count})")
                .ToList()
                .ForEach(Console.WriteLine); */
            
            /* var result = context.Authors
                .OrderByDescending(a => a.Books.Count)
                .ThenByDescending(a => a.Name)
                .Select(a => $"{a.Name} ({a.Books.Count})")
                .First();
            Console.WriteLine(result); */

            /* var result = context.Authors
                // .Where(a => a.Books.Count > 5)
                // .Where(a => a.Id == 1008)
                .Select(a => $"{a.Name} ({a.Books.Count})")
                // .First();
                // .FirstOrDefault();
                .SingleOrDefault(); */
            /* var result = context.Authors
                .Find(1008);
            Console.WriteLine(result.Books.Count); */
            // var result = context.Books.Find(1);
            /* var result =
                context.Books.Include(b => b.Author)
                    .SingleOrDefault(b => b.Id == 1); */
            /* var result = context.Books.Find(1);
            Console.WriteLine(result.Title);
            Console.WriteLine(result.Author != null ? result.Author.Name : "No Author Info");
            context.Entry(result).Reference(b => b.Author).Load();
            Console.WriteLine(result.Author != null ? result.Author.Name : "No Author Info");
            // Console.WriteLine($"{result.Name} ({context.Books.Where(b => b.AuthorId == 1008).Count()})"); */
            var g1 = new Group() {Name = "911"};
            context.Groups.Add(g1);
            context.Students.Add(new Student() {Name = "The First Student", Group = g1});
            context.SaveChanges();
            context.Groups.Select(g => $"{g.Name} (${g.Students.Count} students)")
                .ToList()
                .ForEach(Console.WriteLine);
            g1.Name = "911-2";
            context.SaveChanges();
            context.Groups.Select(g => $"{g.Name} (${g.Students.Count} students)")
                .ToList()
                .ForEach(Console.WriteLine);
            context.Students.Remove(
                context.Students.Where(s => s.GroupId == g1.Id).SingleOrDefault()
            );
            context.SaveChanges();
            context.Groups.Select(g => $"{g.Name} (${g.Students.Count} students)")
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}