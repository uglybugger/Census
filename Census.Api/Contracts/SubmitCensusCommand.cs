using System.ComponentModel.DataAnnotations;
using Census.Api.Domain;

namespace Census.Api.Contracts
{
    public class SubmitCensusCommand : ICommand
    {
        public const string RouteTemplate = "api/census/submit";

        [Required]
        public SubmissionDto Submission { get; set; }
    }
}