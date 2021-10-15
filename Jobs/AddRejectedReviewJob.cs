using zebee_demo.Models;
using Zeebe.Client.Api.Responses;
using Zeebe.Client.Bootstrap.Abstractions;

namespace zeebe_demo.Jobs
{
    public class AddRejectedReviewJob : AbstractJob<ProcessState>
    {
        public AddRejectedReviewJob(IJob job, ProcessState state) : base(job, state) { }
    }
}