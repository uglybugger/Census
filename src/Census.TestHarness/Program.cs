using System;
using System.Threading;
using System.Threading.Tasks;
using Census.Client;
using Census.Contracts.Contracts;
using Census.Contracts.Contracts.Submission;

namespace Census.TestHarness
{
    class Program
    {
        private static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        public static async Task MainAsync()
        {
            var apiClient = new CensusApiClient(new Uri("https://api.hipstercensus.com/"));

            for (var i = 0; i < 1000; i++)
            {
                try
                {
                    var completedCensus = new CompletedCensusDto
                                          {
                                              Id = Guid.NewGuid(),
                                              AccessToken = "0000-0000-0000-0000",
                                              LegalName = "Eustace Gronk III",
                                              BaristaName = "Pony",
                                              BeardLength = 140,
                                              GearInches = 120,
                                              BeerBitterness = 110,
                                              FavouriteBand = "You've never heard of them"
                                          };
                    var command = new SubmitCensusCommand(completedCensus);
                    await apiClient.Send(command, CancellationToken.None);
                    Console.WriteLine($"Request completed at {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}