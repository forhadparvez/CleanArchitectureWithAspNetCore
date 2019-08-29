using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Persistence
{
    public class AppDbInitializer
    {

        private readonly Dictionary<int, Student> Students = new Dictionary<int, Student>();


        public static void Initialize(AppDbContext context)
        {
            var initializer = new AppDbInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return; // Db has been seeded
            }

            SeedStudents(context);
        }

        private void SeedStudents(AppDbContext context)
        {
            var students = new[]
            {
                new Student {  Name = "A", Age=10, Roll="1001"}
            };

            context.Students.AddRange(students);

            context.SaveChanges();
        }

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }
}
