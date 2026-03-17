namespace Core
{
    // Клас, що описує саме фото
    public class Photo
    {
        public string FileName { get; set; }     // назва файлу
        public double FileSizeMb { get; set; }   // розмір у МБ
        public DateTime UploadDate { get; set; } // дата завантаження
    }

    // Клас, що описує користувача системи
    public class User
    {
        public string UserName { get; set; }     // ім'я
        public int UploadLimit { get; set; }     // ліміт на кількість фото
        public bool IsProAccount { get; set; }   // чи активована Pro-підписка
    }

    // Клас для тегування зображень
    public class ImageTag
    {
        public string TagName { get; set; }      // назва тегу (напр. "Природа")
        public int UsageCount { get; set; }      // скільки разів використано
        public bool IsHidden { get; set; }       // чи прихований тег
    }
}