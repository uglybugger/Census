using System.Linq;
using System.Threading.Tasks;
using Census.Api.AppSettings;
using Census.Api.Domain;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Census.Api.Infrastructure.Persistence
{
    public class DocumentClientFactory
    {
        private readonly CosmosDbSettings _cosmosDbSettings;

        public DocumentClientFactory(CosmosDbSettings cosmosDbSettings)
        {
            _cosmosDbSettings = cosmosDbSettings;
        }

        public DocumentClient Create()
        {
            var endpointUri = _cosmosDbSettings.Endpoint;
            var key = _cosmosDbSettings.Key;
            var client = new DocumentClient(endpointUri, key);

            ConfigureDocumentClient(client).Wait();

            return client;
        }

        private async Task ConfigureDocumentClient(DocumentClient client)
        {
            await client.CreateDatabaseIfNotExistsAsync(new Database {Id = _cosmosDbSettings.DatabaseName});

            var aggregateRootTypes = GetType()
                                     .Assembly.DefinedTypes
                                     .Where(t => typeof(IAggregateRoot).IsAssignableFrom(t))
                                     .Where(t => !t.IsInterface)
                                     .Where(t => !t.IsAbstract)
                                     .ToArray();

            foreach (var aggregateRootType in aggregateRootTypes)
            {
                var databaseUri = UriFactory.CreateDatabaseUri(_cosmosDbSettings.DatabaseName);
                var documentCollection = new DocumentCollection {Id = aggregateRootType.Name};
                await client.CreateDocumentCollectionIfNotExistsAsync(databaseUri, documentCollection);
            }
        }
    }
}