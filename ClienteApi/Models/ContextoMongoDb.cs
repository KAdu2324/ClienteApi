using MongoDB.Driver;

namespace ClienteApi.Models
{
    public class ContextoMongoDb
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;

        public string ContextoCollectionName { get; set; } = null;

       

    }
}
