using System;
using System.Linq;
using System.Threading.Channels;

namespace EFCoreDataBaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello EF Core!");
            LibraryContext context = new LibraryContext();
            context.Books.Select(b => $"{b.Title} ({b.Author.Name})")
                .ToList().ForEach(Console.WriteLine);
            /* Author a = new Author() {Name = "June Four"};
            context.Authors.Add(a);
            context.Books.Add(new Book() {Title = "B4", Author = a});
            context.SaveChanges(); */
        }
    }
}