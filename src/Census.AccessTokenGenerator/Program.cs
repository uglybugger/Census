using System;
using System.Linq;
using Census.Contracts.Validation.Attributes;
using Newtonsoft.Json;

namespace Census.AccessTokenGenerator
{
    public static class Program
    {
        private static void Main()
        {
            var accessTokenGenerator = new AccessTokenCalculator();
            var tokens = Enumerable.Range(0, 1000)
                                   .Select(i => accessTokenGenerator.GenerateAccessToken())
                                   .ToArray();
            JsonSerializer.Create().Serialize(Console.Out, tokens);
        }
    }
}