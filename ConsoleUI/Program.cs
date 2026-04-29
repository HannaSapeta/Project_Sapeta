using System;
using System.Text;
using Core;

Console.OutputEncoding = Encoding.UTF8;

PhotoStorage storage = new PhotoStorage();
storage.AddPhoto(new Photo("vacation_2023.jpg", 4.5, DateTime.Now));
storage.AddPhoto(new Photo("work_document.pdf", 1.2, DateTime.Now.AddDays(-1)));
storage.AddPhoto(new Photo("family_tree.png", 8.9, DateTime.Now.AddDays(-5)));

Console.WriteLine("=== 1. Ітерація через контейнер (yield return) ===");
foreach (var photo in storage) 
{
    Console.WriteLine($"Файл: {photo.FileName}, Розмір: {photo.FileSizeMb.ToFriendlySize()}");
}

Console.WriteLine("\n=== 2. Швидкий пошук у Dictionary ===");
string searchName = "family_tree.png";
var found = storage.FindByFileName(searchName);
Console.WriteLine(found != null ? $"Знайдено: {found.FileName}" : "Не знайдено");

Console.WriteLine("\n=== 3. Робота з HashSet (Унікальність та Перетин) ===");
HashSet<string> tagsUser1 = new HashSet<string> { "гори", "відпустка", "літо" };
HashSet<string> tagsUser2 = new HashSet<string> { "море", "літо", "сонце" };

bool added = tagsUser1.Add("гори");
Console.WriteLine($"Спроба додати дублікат 'гори': {added} (колекція не змінилася)");

HashSet<string> commonTags = new HashSet<string>(tagsUser1);
commonTags.IntersectWith(tagsUser2);

Console.WriteLine("Спільні теги для двох користувачів:");
foreach (var tag in commonTags) Console.WriteLine($"- {tag}");

Console.WriteLine("\n=== 4. Аналіз рядків (Методи розширення) ===");
string testName = "my_new_photo_collection.jpg";
Console.WriteLine($"Назва: {testName}");
Console.WriteLine($"Кількість слів у назві: {testName.WordCount()}");

Console.ReadLine();