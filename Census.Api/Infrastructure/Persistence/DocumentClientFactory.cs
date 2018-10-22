using System;
using System.Linq;
using System.Threading.Tasks;
using Census.Api.Domain;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Census.Api.Infrastructure.Persistence
{
    public class DocumentClientFactory
    {
        public DocumentClient Create()
        {
            // these will only work on a local development instance. Sorry ;)
            var endpointUri = new Uri("https://localhost:8081");
            var key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
            var client = new DocumentClient(endpointUri, key);

            ConfigureDocumentClient(client).Wait();

            return client;
        }

        private async Task ConfigureDocumentClient(DocumentClient client)
        {
            await client.CreateDatabaseIfNotExistsAsync(new Database {Id = "hipster-census"});

            var aggregateRootTypes = GetType().Assembly.DefinedTypes
                .Where(t => typeof(IAggregateRoot).IsAssignableFrom(t))
                .Where(t => !t.IsInterface)
                .Where(t => !t.IsAbstract)
                .ToArray();

            foreach (var aggregateRootType in aggregateRootTypes)
            {
                await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("hipster-census"), new DocumentCollection {Id = aggregateRootType.Name});
            }
        }
    }
}