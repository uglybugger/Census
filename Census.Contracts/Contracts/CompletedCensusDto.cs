using System;
using System.ComponentModel.DataAnnotations;
using Census.Contracts.Validation.Attributes;

namespace Census.Contracts.Contracts
{
    public class CompletedCensusDto
    {
        [Required]
        [NotEmpty]
        public Guid Id { get; set; }

        [Required]
        [MagicCensusToken]
        public string AccessToken { get; set; }

        [Required]
        [Range(1, 300)]
        public int BeardLength { get; set; }

        [Required]
        [Range(100, 200)]
        public int GearInches { get; set; }
    }
}