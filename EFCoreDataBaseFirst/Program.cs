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
            // создание объекта сущности Группа,
            // не связанного с БД
            var g1 = new Group() {Name = "911"};
            // в слое логики добавляем выше созданный объект
            context.Groups.Add(g1);
            // там же добавляем объект Студент,
            // ссылающийся на новую группу
            context.Students.Add(new Student() {Name = "The First Student", Group = g1});
            // все накопившиеся изменения отображаем в слой данных
            // (сохраняем изменения: две вставки строк в две разные таблицы)
            context.SaveChanges();
            // получаем весь список групп с количеством студентов в каждой из них
            // (одна группа с одним студентом)
            context.Groups.Select(g => $"{g.Name} (${g.Students.Count} students)")
                .ToList()
                .ForEach(Console.WriteLine);
            // меняем название группы в объекте, то есть в слое логики
            g1.Name = "911-2";
            // отображение изменений в слой данных:
            // формирование и выполнение команды обновления для таблицы Группы,
            // для единственной группы g1
            context.SaveChanges();
            // просматриваем изменения, снова прочитав данные из базы
            context.Groups.Select(g => $"{g.Name} (${g.Students.Count} students)")
                .ToList()
                .ForEach(Console.WriteLine);
            // в слое логики удаляем объект студента
            context.Students.Remove(
                context.Students.Where(s => s.GroupId == g1.Id).SingleOrDefault()
            );
            // отображаем удаление в БД
            context.SaveChanges();
            // просматриваем изменения, снова прочитав данные из базы
            context.Groups.Select(g => $"{g.Name} (${g.Students.Count} students)")
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}