using Affordability.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Affordability
{
    public class Data : IData
    {
        private readonly HttpClient _httpClient;
        public Data(HttpClient client)
        {
            _httpClient = client;
        }
        static string albumUrl = "http://jsonplaceholder.typicode.com/albums";
        static string photoUrl = "http://jsonplaceholder.typicode.com/photos";

        public async Task<List<Album>> GetAlbumsAsync()
        {
            try
            {
                var albums = new List<Album>();
                HttpResponseMessage response = await _httpClient.GetAsync(albumUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    if (result != null)
                    {
                        albums = JsonConvert.DeserializeObject<List<Album>>(result);
                    }
                }
                return albums;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Photo>> GetPhotosAsync()
        {
            try
            {
                var photos = new List<Photo>();
                HttpResponseMessage response = await _httpClient.GetAsync(photoUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    if (result != null)
                    {
                        photos = JsonConvert.DeserializeObject<List<Photo>>(result);
                    }
                }
                return photos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Album> Combine()
        {
            var photos = GetPhotosAsync().Result;
            var albums = GetAlbumsAsync().Result;

            if (photos.Count > 0 && albums.Count > 0)
            {
                for (int i = 0; i < albums.Count; i++)

                {
                    foreach (var photo in photos)
                    {
                        if (photo.albumId == albums[i].id)
                        {
                            albums[i].photo.Add(photo);
                        }
                    }
                }
                return albums;
            }

            return null;
        }
    }
}
