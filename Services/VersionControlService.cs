using MongoDB.Driver;
using MongoDbDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbDemo.Services
{
    public class VersionControlService
    {
        private readonly IMongoCollection<VersionControl> _versionControlCollection;

        public VersionControlService(IMongoDatabase database)
        {
            _versionControlCollection = database.GetCollection<VersionControl>("VersionControl");
        }

        public async Task<List<VersionControl>> GetAllAsync()
        {
            return await _versionControlCollection.Find(_ => true).ToListAsync();
        }

        public async Task CreateAsync(VersionControl versionControl)
        {
            await _versionControlCollection.InsertOneAsync(versionControl);
        }
    }
}
