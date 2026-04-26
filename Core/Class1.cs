using System;

namespace Core
{
    // Пункт 2: Структура для ціни/вартості фото (наприклад, для фотостоку)
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

        // Пункт 4: Конструктор
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
}