using System;
using System.Text;
using Core; // Це дозволяє консолі бачити класи Photo, User та ImageTag

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. ВИПРАВЛЕННЯ КОДУВАННЯ (щоб відображалася літери "і", "ї", "є")
            Console.OutputEncoding = Encoding.UTF8;

            // 2. СТВОРЕННЯ ЕКЗЕМПЛЯРІВ ТА ІНІЦІАЛІЗАЦІЯ ДАНИМИ

            // Екземпляр для фото
            Photo myPhoto = new Photo
            {
                FileName = "trip_to_carpathians.png",
                FileSizeMb = 5.75,
                UploadDate = DateTime.Now
            };

            // Екземпляр для користувача
            User activeUser = new User
            {
                UserName = "Oleksandr_99",
                UploadLimit = 100,
                IsProAccount = false
            };

            // Екземпляр для тегу
            ImageTag photoTag = new ImageTag
            {
                TagName = "Гори",
                UsageCount = 42,
                IsHidden = false
            };

            // 3. ВИВІД СИСТЕМНОЇ ІНФОРМАЦІЇ (як вимагає завдання)
            Console.WriteLine("======= СИСТЕМНА ІНФОРМАЦІЯ =======");
            Console.WriteLine($"ОС: {Environment.OSVersion}");
            Console.WriteLine($"Пам'ять: {GC.GetTotalMemory(false) / 1024} KB");
            Console.WriteLine("===================================\n");

            // 4. ВИВІД ОПИСУ ОБ'ЄКТІВ
            Console.WriteLine("======= ОПИС ОБ'ЄКТІВ БІБЛІОТЕКИ =======");

            Console.WriteLine("--- Фотографія ---");
            Console.WriteLine($"Назва файлу: {myPhoto.FileName}");
            Console.WriteLine($"Розмір: {myPhoto.FileSizeMb} МБ");
            Console.WriteLine($"Завантажено: {myPhoto.UploadDate}");

            Console.WriteLine("\n--- Користувач ---");
            Console.WriteLine($"Логін: {activeUser.UserName}");
            Console.WriteLine($"Доступний ліміт: {activeUser.UploadLimit} фото");
            Console.WriteLine($"Преміум статус: {(activeUser.IsProAccount ? "Активовано" : "Відсутній")}");

            Console.WriteLine("\n--- Тег зображення ---");
            Console.WriteLine($"Назва тегу: #{photoTag.TagName}");
            Console.WriteLine($"Кількість використань: {photoTag.UsageCount}");

            Console.WriteLine("========================================");

            // Затримка консолі
            Console.WriteLine("\nНатисніть Enter, щоб вийти...");
            Console.ReadLine();
        }
    }
}