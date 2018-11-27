import React from 'react';
import Page from './Page';
import accessTokens from './accessTokens.json';

class AboutPage extends Page {

    render() {
        return (
            <div>
                <h1>About</h1>
                <p>
                    Here's how to create an API client and lodge your own census.
                </p>
                <p>
                    Create a new console application, then install the client library NuGet package:
                </p>
                <pre>
                    {AboutPage.nugetInstallationSampleCode}
                </pre>
                <p>
                    Copy and paste the code below into your Program.cs.
                </p>
                <pre>
                    {AboutPage.sampleCode}
                </pre>

                <p>Each hipster citizen has been issued with a unique access token via snail mail.</p>
                <p>Below is an additional collection of valid access tokens. You may use the access tokens or generate your own - just replace the all-zeroes code with any one of these.</p>
                <pre>
                    {AboutPage.accessTokens}
                </pre>
                <p>
                    You're all set to go. Hit F5 and see what happens :)
                </p>
            </div>
        );
    }
}

AboutPage.accessTokens = JSON.stringify(accessTokens);

AboutPage.nugetInstallationSampleCode = `
Install-Package Census.Client -Source https://www.myget.org/F/census-client/api/v3/index.json

`;

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