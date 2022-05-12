using System.Collections.Generic;

namespace Affordability.Models
{
    public class Album
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public List<Photo> photo { get; set; }

        public Album()
        {
            photo = new List<Photo>();
        }

    }


}
