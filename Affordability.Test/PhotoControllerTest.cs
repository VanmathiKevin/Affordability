using Affordability.Controllers;
using System;
using System.Net.Http;
using Xunit;

namespace Affordability.Test
{
    public class PhotoControllerTest
    {
        PhotoController _photoController;
        Data _data;
        static HttpClient httpClient = new HttpClient();

        //Mock photos and albums data instead of fetching from endpoint 
        //Negative test cases should be written
        public PhotoControllerTest()
        {
            _photoController = new PhotoController();
            _data = new Data(httpClient);
        }

        [Fact]
        public void GetPhotos_ReturnAlbumWithPhotos()
        {
            //Act
            var result = _photoController.GetPhotos();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetPhotosById_ReturnAlbumWithPhotosByUserID()
        {
            int id = 2;
            //Act
            var result = _photoController.GetbyUserId(id);

            //Assert
            Assert.NotNull(result);
        }
    }
}
