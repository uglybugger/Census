using System.ComponentModel.DataAnnotations;
using Census.Contracts.HttpRequestRouting.Attributes;

namespace Census.Contracts.Contracts
{
    [Post(RouteTemplate)]
    public class SubmitCensusCommand : ICommand
    {
        public const string RouteTemplate = "api/census/submit";

        [Required]
        public CompletedCensusDto CompletedCensus { get; set; }

        public SubmitCensusCommand()
        {
        }

        public SubmitCensusCommand(CompletedCensusDto completedCensus)
        {
            CompletedCensus = completedCensus;
        }
    }
}