using zebee_demo;
using Zeebe.Client.Api.Responses;
using Zeebe.Client.Bootstrap.Abstractions;

namespace zeebe_demo.Jobs
{
    public class AnalyzeSentimentJob : AbstractJob<ProcessState>
    {
        public AnalyzeSentimentJob(IJob job, ProcessState state) : base(job, state) { }
    }
}