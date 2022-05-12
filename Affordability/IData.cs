using Affordability.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Affordability
{
    public interface IData
    {
        Task<List<Album>> GetAlbumsAsync();

        Task<List<Photo>> GetPhotosAsync();
    }
}
