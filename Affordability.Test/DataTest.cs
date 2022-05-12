using System;
using System.Net.Http;
using Xunit;

namespace Affordability.Test
{
    public class DataTest
    {
        HttpClient _httpClient;
        Data _data;
        public DataTest()
        {
            _httpClient = new HttpClient();
            _data = new Data(_httpClient);
        }

        //Mock photos and albums data instead of fetching from endpoint.
        //Negative test cases should be written.

        [Fact]
        public void GetPhotoData_ReturnsAllPhotos()
        {
            //Act
            var result = _data.GetPhotosAsync();
            var list = result.Result;

            //Assert
            Assert.NotNull(list);
            Assert.Equal(5000, list.Count);

        }

        [Fact]
        public void GetAlbumData_ReturnsAllAlbums()
        {
            //Act
            var result = _data.GetAlbumsAsync();
            var list = result.Result;

            //Assert
            Assert.NotNull(list);
            Assert.Equal(100, list.Count);

        }

        [Fact]
        public void GetCombinedData_ReturnsAlbumsWithPhotos()
        {
            //Act
            var result = _data.Combine();
            var list = result;

            //Assert
            Assert.NotNull(list);
            Assert.Equal(100, list.Count);

        }
    }
}
