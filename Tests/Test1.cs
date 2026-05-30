using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using WpfUI.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class PhotoTests
    {
        [TestMethod]
        public void CreatePhotoTest()
        {
            Photo photo = new Photo(
                "photo.jpg",
                5,
                "1920x1080");

            Assert.AreEqual(
                "photo.jpg",
                photo.FileName);
        }

        [TestMethod]
        public void AddPhotoTest()
        {
            MainViewModel vm = new MainViewModel();

            int count = vm.Photos.Count;

            vm.AddCommand.Execute(null);

            Assert.AreEqual(
                count + 1,
                vm.Photos.Count);
        }

        [TestMethod]
        public void DeletePhotoTest()
        {
            MainViewModel vm = new MainViewModel();

            Photo photo = new Photo(
                "1.jpg",
                2,
                "800x600");

            vm.Photos.Add(photo);

            vm.SelectedPhoto = photo;

            vm.DeleteCommand.Execute(null);

            Assert.AreEqual(
                0,
                vm.Photos.Count);
        }

        [TestMethod]
        public void LinqFilterTest()
        {
            List<Photo> photos = new List<Photo>
            {
                new Photo("a", 1, "1"),
                new Photo("b", 10, "1"),
                new Photo("c", 15, "1")
            };

            var result = photos
                .Where(x => x.FileSizeMb > 5)
                .ToList();

            Assert.AreEqual(
                2,
                result.Count);
        }

        [TestMethod]
        public void PhotoNameValidation()
        {
            Photo photo = new Photo();

            photo.FileName = "";

            Assert.IsTrue(
                string.IsNullOrWhiteSpace(
                    photo.FileName));
        }
    }
}
