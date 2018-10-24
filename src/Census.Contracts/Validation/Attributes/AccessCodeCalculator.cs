using System;
using System.Collections.Generic;
using System.Globalization;

namespace Census.Contracts.Validation.Attributes
{
    internal class AccessCodeCalculator
    {
        private readonly Random _random = new Random();
        private const ulong _codeMask = 0xFFFFFFFFFFFF0000;
        private const ulong _checksumMask = 0x000000000000FFFF;

        internal bool IsValid(string accessCode)
        {
            var sanitizedAccessCode = string.Join(string.Empty, accessCode.Split('-'));

            if (!ulong.TryParse(sanitizedAccessCode, NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat, out ulong ulongAccessCode))
            {
                return false;
            }

            var isValid = IsValid(ulongAccessCode);
            return isValid;
        }

        internal bool IsValid(ulong ulongAccessCode)
        {
            var code = ulongAccessCode & _codeMask;
            var checksum = ulongAccessCode & _checksumMask;

            var expectedChecksum = CalculateChecksum(code);

            var isValid = checksum == expectedChecksum;
            return isValid;
        }

        internal string GenerateAccessCode()
        {
            var ulongAccessCode = GenerateULongAccessCode();
            var accessCode = ulongAccessCode.ToString("x016");
            var chunks = new List<string>();
            for (var i = 0; i < accessCode.Length; i += 4)
            {
                var chunk = accessCode.Substring(i, 4);
                chunks.Add(chunk);
            }

            var formattedAccessCode = string.Join("-", chunks);
            return formattedAccessCode;
        }

        internal ulong GenerateULongAccessCode()
        {
            var code = ((ulong) _random.Next() << 32 + _random.Next()) & _codeMask;
            var checksum = CalculateChecksum(code);

            var accessCode = code | checksum;
            return accessCode;
        }

        internal ulong CalculateChecksum(ulong code)
        {
            var checksum = code % 23;
            return checksum;
        }
    }
}