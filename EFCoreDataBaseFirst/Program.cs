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
            var result = context.Authors
                .Find(1008);
            Console.WriteLine($"{result.Name} ({context.Books.Where(b => b.AuthorId == 1008).Count()})");
        }
    }
}