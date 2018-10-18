using System;
using System.ComponentModel.DataAnnotations;
using Census.Api.Validation;

namespace Census.Api.Contracts
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