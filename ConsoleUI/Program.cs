using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using Core;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string jsonPath = "library.json";

            List<Photo> photoLibrary = new List<Photo>
            {
                new Photo("carpathians.jpg", 5.2, "4000x3000"),
                new Photo("sea_side.png", 12.8, "5000x4000")
            };

            // Серіалізація
            string jsonString = JsonSerializer.Serialize(photoLibrary, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonPath, jsonString);

            // Десеріалізація з виправленням CS8600 та CS8602
            if (File.Exists(jsonPath))
            {
                string rawJson = File.ReadAllText(jsonPath);

                // Використовуємо '?' для допустимості null та перевірку
                List<Photo>? restoredPhotos = JsonSerializer.Deserialize<List<Photo>>(rawJson);

                Console.WriteLine("=== Список фото з файлу ===");
                if (restoredPhotos != null) // Перевірка прибирає помилку CS8602
                {
                    foreach (var p in restoredPhotos)
                    {
                        // Перевірка кожного об'єкта
                        if (p != null)
                        {
                            Console.WriteLine($"- {p.FileName} [{p.Resolution}]");
                        }
                    }
                }
            }

            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}
