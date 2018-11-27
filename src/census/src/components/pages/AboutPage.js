import React from 'react';
import Page from './Page';
import accessTokens from './accessTokens.json';

class AboutPage extends Page {

    render() {
        return (
            <div>
                <h1>About</h1>
                <h2>Test harness</h2>
                <p>
                    Here's how to create an API client and lodge your own census:
                </p>
                <pre>
                    {AboutPage.sampleCode}
                </pre>

                <h2>Access tokens</h2>
                <p>Each hipster citizen has been issued with a unique access token via snail mail.</p>
                <p>Below is an additional collection of valid access tokens. You may use the access codes or generate your own.</p>
                <pre>
                    {JSON.stringify(accessTokens)}
                </pre>
            </div>
        );
    }
}

AboutPage.sampleCode = `
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
`;

AboutPage.propTypes = {
};

export default AboutPage;