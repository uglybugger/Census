using System;
using System.Collections.Generic;
using System.Globalization;

namespace Census.Contracts.Validation.Attributes
{
    internal class AccessTokenCalculator
    {
        private readonly Random _random = new Random();
        private const ulong _codeMask = 0xFFFFFFFFFFFF0000;
        private const ulong _checksumMask = 0x000000000000FFFF;

        internal bool IsValid(string accessToken)
        {
            var sanitizedAccessToken = string.Join(string.Empty, accessToken.Split('-'));

            if (!ulong.TryParse(sanitizedAccessToken, NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat, out ulong ulongAccessToken))
            {
                return false;
            }

            var isValid = IsValid(ulongAccessToken);
            return isValid;
        }

        internal bool IsValid(ulong ulongAccessToken)
        {
            if (ulongAccessToken == 0) return false;    // nice try..

            var code = ulongAccessToken & _codeMask;
            var checksum = ulongAccessToken & _checksumMask;

            var expectedChecksum = CalculateChecksum(code);

            var isValid = checksum == expectedChecksum;
            return isValid;
        }

        internal string GenerateAccessToken()
        {
            var ulongAccessToken = GenerateULongAccessToken();
            var accessToken = ulongAccessToken.ToString("x016");
            var chunks = new List<string>();
            for (var i = 0; i < accessToken.Length; i += 4)
            {
                var chunk = accessToken.Substring(i, 4);
                chunks.Add(chunk);
            }

            var formattedAccessToken = string.Join("-", chunks);
            return formattedAccessToken;
        }

        internal ulong GenerateULongAccessToken()
        {
            ulong code = 0;
            while (code == 0)
            {
                // zero is special. It will validate but we don't want it to so we just have another go if we happen to generate a zero random value.
                code = ((ulong)_random.Next() << 32 + _random.Next()) & _codeMask;
            }
            var checksum = CalculateChecksum(code);

            var accessToken = code | checksum;
            return accessToken;
        }

        internal ulong CalculateChecksum(ulong code)
        {
            var checksum = code % 23;
            return checksum;
        }
    }
}