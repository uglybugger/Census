using System;
using System.ComponentModel.DataAnnotations;
using Census.Contracts.Validation.Attributes;

namespace Census.Contracts.Contracts
{
    public class SubmissionDto
    {
        [Required]
        [NotEmpty]
        public Guid Id { get; set; }

        [Required]
        public string Token { get; set; }
    }
}