using BlockbusterClone.Models;

namespace BlockbusterClone.Services
{
    public interface IBlockbusterServices
    {
        List<Movies> GetMovies();
        Movies GetDetails(string id);
        Movies Create(Movies movies);
        void Update(string id, Movies movies);
        void Remove(string id);
    }
}
