using BlockbusterClone.Models;
using MongoDB.Driver;

namespace BlockbusterClone.Services
{
    public class BlockbusterServices : IBlockbusterServices
    {
        private readonly IMongoCollection<Movies> _blockbuster;

        public BlockbusterServices(IBlockbusterDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _blockbuster = database.GetCollection<Movies>(settings.BlockbusterCollection);
        }
        public Movies Create(Movies movies)
        {
            _blockbuster.InsertOne(movies);
            return movies;
        }

        public List<Movies> GetMovies()
        {
            return _blockbuster.Find(movies => true).ToList();
        }
        public Movies GetDetails(string id)
        {
            return _blockbuster.Find(movies => movies.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _blockbuster.DeleteOne(movies => movies.Id == id);
        }

        public void Update(string id, Movies movies)
        {
            _blockbuster.ReplaceOne(movies => movies.Id == id, movies);
        }
    }
}
