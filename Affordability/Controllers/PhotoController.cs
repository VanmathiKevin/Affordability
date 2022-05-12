using Affordability.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
//using System.Web.Http;
//using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Affordability.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        //private readonly ILogger<PhotoController> _logger;
        static HttpClient httpClient = new HttpClient();
        Data data = new Data(httpClient);

        public PhotoController()
        {
            //_logger = logger;
        }

        [HttpGet]
        public IActionResult GetPhotos()
        {
            //_logger.LogInformation("Fetching all albums with photos");
            var result = JsonConvert.SerializeObject(data.Combine(), Formatting.Indented);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyUserId(int id)
        {
            string result = null;
            //_logger.LogInformation("Fetching all albums with photos");

            var albumList = data.Combine();
            var userIdList = albumList.Select(a => a.userId).ToList();
            if (userIdList.Contains(id))
            {
                //_logger.LogInformation("Fetching album for userid {id}");

                var filteredAlbums = albumList.Where(a => a.userId == id);
                result = JsonConvert.SerializeObject(filteredAlbums, Formatting.Indented);
            }
            else
            {
                
                throw new Exception("Invalid user id");
                //_logger.LogInformation("Invalid user id");
            }
            return Ok(result);
        }

    }
}
