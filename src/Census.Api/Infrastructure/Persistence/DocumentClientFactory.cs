using System.Linq;
using System.Threading.Tasks;
using Census.Api.AppSettings;
using Census.Api.Domain;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Serilog;

namespace Census.Api.Infrastructure.Persistence
{
    public class DocumentClientFactory
    {
        private readonly CosmosDbSettings _cosmosDbSettings;
        private readonly ILogger _logger;

        public DocumentClientFactory(CosmosDbSettings cosmosDbSettings, ILogger logger)
        {
            _cosmosDbSettings = cosmosDbSettings;
            _logger = logger;
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
            _logger.Debug("Creating database {DatabaseName} if it doesn't already exist...", _cosmosDbSettings.DatabaseName);
            await client.CreateDatabaseIfNotExistsAsync(new Database {Id = _cosmosDbSettings.DatabaseName});

            var aggregateRootTypes = GetType()
                                     .Assembly.DefinedTypes
                                     .Where(t => typeof(IAggregateRoot).IsAssignableFrom(t))
                                     .Where(t => !t.IsInterface)
                                     .Where(t => !t.IsAbstract)
                                     .ToArray();

            var databaseUri = UriFactory.CreateDatabaseUri(_cosmosDbSettings.DatabaseName);
            foreach (var aggregateRootType in aggregateRootTypes)
            {
                var documentCollection = new DocumentCollection {Id = aggregateRootType.Name};
                _logger.Debug("Creating document collection {DocumentCollectionId} if it doesn't already exist.", documentCollection.Id);
                await client.CreateDocumentCollectionIfNotExistsAsync(databaseUri, documentCollection);
            }

            _logger.Debug("Configured document client.");
        }
    }
}