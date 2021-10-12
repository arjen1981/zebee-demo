using Zeebe.Client.Api.Responses;
using Zeebe.Client.Bootstrap.Abstractions;
using Zeebe.Client.Bootstrap.Attributes;

namespace zeebe_demo.Jobs
{
    [FetchVariables("review")]
    public class AnalyzeSentimentJob : AbstractJob
    {
        public AnalyzeSentimentJob(IJob job) : base(job)
        {
        }
    }
}