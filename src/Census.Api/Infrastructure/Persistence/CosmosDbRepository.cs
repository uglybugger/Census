using System;
using System.Threading.Tasks;
using Census.Api.AppSettings;
using Microsoft.Azure.Documents.Client;

namespace Census.Api.Infrastructure.Persistence
{
    public class CosmosDbRepository<TAggregateRoot> : IRepository<TAggregateRoot>
    {
        private readonly DocumentClient _client;
        private readonly string _databaseName;

        public CosmosDbRepository(CosmosDbSettings cosmosDbSettings, DocumentClient client)
        {
            _client = client;
            _databaseName = cosmosDbSettings.DatabaseName;
        }

        public async Task Add(TAggregateRoot item)
        {
            var documentCollectionUri = UriFactory.CreateDocumentCollectionUri(_databaseName, typeof(TAggregateRoot).Name);
            await _client.CreateDocumentAsync(documentCollectionUri, item);
        }

        public async Task<TAggregateRoot> Get(Guid id)
        {
            var item = await _client.ReadDocumentAsync<TAggregateRoot>(UriFactory.CreateDocumentUri(_databaseName, typeof(TAggregateRoot).Name, id.ToString()));
            return item;
        }
    }
}