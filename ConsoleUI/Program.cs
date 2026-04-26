using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Core;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // --- ПУНКT 2: Дослідження структур ---
            Console.WriteLine("=== 1. ДОСЛІДЖЕННЯ СТРУКТУР ===");
            PhotoPrice currentPrice = new PhotoPrice(150.0, "UAH");

            void TestStruct(PhotoPrice p)
            {
                p.Amount = 1000.0; // Змінюємо поле всередині методу
                Console.WriteLine($"Всередині методу: {p.Amount}");
            }

            Console.WriteLine($"До методу: {currentPrice.Amount}");
            TestStruct(currentPrice);
            Console.WriteLine($"Після методу (залишилась незмінною): {currentPrice.Amount}\n");


            // --- ПУНКT 3: Boxing/Unboxing та Stopwatch ---
            Console.WriteLine("=== 2. АНАЛІЗ BOXING/UNBOXING ===");
            int myInt = 42;
            object boxed = myInt;       // Boxing
            int unboxed = (int)boxed;   // Unboxing

            int iterations = 1000000;
            Stopwatch sw = new Stopwatch();

            // Тест ArrayList (нетипізований - викликає Boxing)
            ArrayList arrayList = new ArrayList();
            sw.Start();
            for (int i = 0; i < iterations; i++) arrayList.Add(i);
            sw.Stop();
            long timeArrayList = sw.ElapsedMilliseconds;

            // Тест List<int> (типізований - без Boxing)
            sw.Restart();
            List<int> genericList = new List<int>();
            for (int i = 0; i < iterations; i++) genericList.Add(i);
            sw.Stop();
            long timeGenericList = sw.ElapsedMilliseconds;

            Console.WriteLine($"ArrayList (Boxing): {timeArrayList} ms");
            Console.WriteLine($"List<int> (Generic): {timeGenericList} ms");
            Console.WriteLine($"Різниця: {timeArrayList - timeGenericList} ms\n");


            // --- ПУНКТ 4: Колекція з 10 об'єктів ---
            List<Photo> photoLibrary = new List<Photo>
            {
                new Photo("beach.jpg", 2.5, new DateTime(2023, 05, 10)),
                new Photo("mountain.png", 8.2, new DateTime(2023, 06, 15)),
                new Photo("city.jpg", 1.1, new DateTime(2024, 01, 20)),
                new Photo("forest.jpg", 12.5, new DateTime(2023, 08, 05)),
                new Photo("party.png", 5.7, new DateTime(2023, 12, 31)),
                new Photo("coding.jpg", 0.8, new DateTime(2024, 02, 14)),
                new Photo("cat.jpg", 3.3, new DateTime(2024, 03, 01)),
                new Photo("coffee.png", 1.5, new DateTime(2024, 03, 10)),
                new Photo("sky.jpg", 15.0, new DateTime(2023, 07, 22)),
                new Photo("night.jpg", 9.1, new DateTime(2024, 03, 15))
            };


            // --- ПУНКT 5: LINQ Where (Фото > 5 МБ) ---
            var heavyPhotos = photoLibrary.Where(p => p.FileSizeMb > 5).ToList();

            // --- ПУНКT 6: LINQ OrderBy (По даті, потім по розміру) ---
            var sortedPhotos = photoLibrary
                .OrderBy(p => p.UploadDate)
                .ThenBy(p => p.FileSizeMb)
                .ToList();

            // --- ПУНКT 7: LINQ Select (Лише назви файлів) ---
            var onlyNames = photoLibrary.Select(p => p.FileName).ToList();

            // --- ПУНКT 8: FirstOrDefault (Знайти перше фото > 10 МБ) ---
            var hugePhoto = photoLibrary.FirstOrDefault(p => p.FileSizeMb > 10);


            // --- ПУНКT 9: Вивід результатів таблицями ---
            Console.WriteLine("=== 3. РЕЗУЛЬТАТИ LINQ ЗАПИТІВ ===");

            Console.WriteLine("\nТаблиця: Фото більше 5 МБ (Where)");
            PrintTable(heavyPhotos);

            Console.WriteLine("\nТаблиця: Відсортовані фото (OrderBy + ThenBy)");
            PrintTable(sortedPhotos);

            Console.WriteLine("\nСписок назв файлів (Select):");
            foreach (var name in onlyNames) Console.WriteLine($"- {name}");

            Console.WriteLine($"\nПошук фото > 10 МБ (FirstOrDefault):");
            if (hugePhoto != null)
                Console.WriteLine($"Знайдено: {hugePhoto.FileName} ({hugePhoto.FileSizeMb} MB)");
            else
                Console.WriteLine("Об'єкт не знайдено.");

            Console.ReadLine();
        }

        // Метод для зручного виводу таблиці
        static void PrintTable(List<Photo> photos)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("{0,-20} | {1,-10} | {2,-15}", "Назва", "Розмір", "Дата");
            Console.WriteLine("------------------------------------------------------------");
            foreach (var p in photos)
            {
                Console.WriteLine("{0,-20} | {1,-7} MB | {2,-15:dd.MM.yyyy}",
                    p.FileName, p.FileSizeMb, p.UploadDate);
            }
            Console.WriteLine("------------------------------------------------------------");
        }
    }
}