using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;

namespace Census.Api.Infrastructure.Persistence
{
    public class CosmosDbRepository<TAggregateRoot> : IRepository<TAggregateRoot>
    {
        private readonly DocumentClient _client;
        private readonly Uri _documentCollectionUri = UriFactory.CreateDocumentCollectionUri("hipster-census", typeof(TAggregateRoot).Name);

        public CosmosDbRepository(DocumentClient client)
        {
            _client = client;
        }

        public async Task Add(TAggregateRoot item)
        {
            await _client.CreateDocumentAsync(_documentCollectionUri, item);
        }

        public async Task<TAggregateRoot> Get(Guid id)
        {
            var item = await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri("hipster-census", typeof(TAggregateRoot).Name, id.ToString()));
            throw new NotImplementedException();
        }
    }
}