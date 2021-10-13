using System.Threading;
using System.Threading.Tasks;
using Zeebe.Client.Bootstrap.Abstractions;
using zeebe_demo.Jobs;

namespace zeebe_demo.JobHandlers
{
    public class AddRejectedReviewJobHandler : IAsyncJobHandler<AddRejectedReviewJob>
    {
        private readonly StorageService storage;

        public AddRejectedReviewJobHandler(StorageService storage)
        {
            this.storage = storage;
        }

        public Task HandleJob(AddRejectedReviewJob job, CancellationToken cancellationToken)
        {
            var review = job.State;
            this.storage.StoreRejectedReview(review);

            return Task.CompletedTask;
        }
    }
}
