using System;

namespace Core
{
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

    public class Photo
    {
        public string FileName { get; set; }
        public double FileSizeMb { get; set; }
        public DateTime UploadDate { get; set; }

        public Photo(string fileName, double fileSizeMb, DateTime uploadDate)
        {
            FileName = fileName;
            FileSizeMb = fileSizeMb;
            UploadDate = uploadDate;
        }
    }

    public class User
    {
        public string UserName { get; set; }
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
        public string TagName { get; set; }
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

    public class PhotoStorage
    {
        private List<Photo> _photos = new List<Photo>();

        private Dictionary<string, Photo> _photoCache = new Dictionary<string, Photo>();

        public void AddPhoto(Photo photo)
        {
            _photos.Add(photo);
            if (!_photoCache.ContainsKey(photo.FileName))
                _photoCache.Add(photo.FileName, photo);
        }

        public IEnumerator<Photo> GetEnumerator()
        {
            foreach (var photo in _photos)
            {
                yield return photo;
            }
        }

        public Photo FindByFileName(string fileName)
        {
            _photoCache.TryGetValue(fileName, out Photo result);
            return result;
        }

        public List<Photo> GetLargePhotosFromCache(double minSize)
        {
            return _photoCache.Values.Where(p => p.FileSizeMb > minSize).ToList();
        }
    }
}