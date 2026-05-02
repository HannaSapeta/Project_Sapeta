using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public interface IProcessable
    {
        void Process();
    }

    public abstract class MediaFile : IProcessable
    {
        public string FileName { get; set; } = string.Empty;
        public double FileSizeMb { get; set; }

        public MediaFile() { }

        protected MediaFile(string fileName, double fileSizeMb)
        {
            FileName = fileName;
            FileSizeMb = fileSizeMb;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Файл: {FileName}, Розмір: {FileSizeMb} MB");
        }

        public abstract void Process();
    }

    public class Photo : MediaFile
    {
        public string Resolution { get; set; } = string.Empty;

        public Photo() : base() { }

        public Photo(string fileName, double fileSizeMb, string resolution)
            : base(fileName, fileSizeMb)
        {
            Resolution = resolution;
        }

        public override void Process()
        {
            Console.WriteLine($"[Обробка Фото]: Зміна розміру {FileName}");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Тип: Фото, Роздільна здатність: {Resolution}");
        }
    }

    public class Video : MediaFile
    {
        public int DurationSeconds { get; set; }

        public Video() : base() { }

        public Video(string fileName, double fileSizeMb, int duration)
            : base(fileName, fileSizeMb)
        {
            DurationSeconds = duration;
        }

        public override void Process()
        {
            Console.WriteLine($"[Обробка Відео]: Рендеринг {FileName}");
        }
    }

    public class LibraryConfig
    {
        public string Version { get; set; } = "4.0.0-OOP";
    }

    public class LibraryManager
    {
        private readonly LibraryConfig _config = new LibraryConfig();
        private readonly List<MediaFile> _items = new List<MediaFile>();

        public void AddMedia(MediaFile item)
        {
            _items.Add(item);
        }

        public void RemoveMedia(MediaFile item)
        {
            _items.Remove(item);
        }

        public List<MediaFile> GetAllMedia() => _items;

        public void ShowVersion()
        {
            Console.WriteLine($"Версія бібліотеки: {_config.Version}");
        }
    }

    public struct PhotoPrice
    {
        public double Amount { get; set; }
        public string Currency { get; set; }

        public PhotoPrice(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }

    public class User
    {
        public string UserName { get; set; } = string.Empty;
        public int UploadLimit { get; set; }
        public bool IsProAccount { get; set; }

        public User(string userName, int uploadLimit, bool isProAccount)
        {
            UserName = userName;
            UploadLimit = uploadLimit;
            IsProAccount = isProAccount;
        }
    }

    public class ImageTag
    {
        public string TagName { get; set; } = string.Empty;
        public int UsageCount { get; set; }
        public bool IsHidden { get; set; }

        public ImageTag(string tagName, int usageCount, bool isHidden)
        {
            TagName = tagName;
            UsageCount = usageCount;
            IsHidden = isHidden;
        }
    }

    public static class Extensions
    {
        public static string ToFriendlySize(this double sizeMb)
        {
            return $"{sizeMb:F2} MB";
        }

        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            return str.Split(new[] { ' ', '_', '.' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }

    public class PhotoStorage : IEnumerable<Photo>
    {
        private readonly List<Photo> _photos = new List<Photo>();
        private readonly Dictionary<string, Photo> _photoCache = new Dictionary<string, Photo>();

        public void AddPhoto(Photo photo)
        {
            _photos.Add(photo);

            if (!_photoCache.ContainsKey(photo.FileName))
                _photoCache.Add(photo.FileName, photo);
        }

        public IEnumerator<Photo> GetEnumerator()
        {
            return _photos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Photo? FindByFileName(string fileName)
        {
            _photoCache.TryGetValue(fileName, out var result);
            return result;
        }

        public List<Photo> GetLargePhotosFromCache(double minSize)
        {
            return _photoCache.Values.Where(p => p.FileSizeMb > minSize).ToList();
        }
    }
}
