using System.Threading;
using System.Threading.Tasks;
using Zeebe.Client.Bootstrap.Abstractions;
using zeebe_demo.Jobs;

namespace zeebe_demo.JobHandlers
{
    public class AddReviewJobHandler : IAsyncJobHandler<AddReviewJob>
    {
        private readonly StorageService storage;

        public AddReviewJobHandler(StorageService storage)
        {
            this.storage = storage;
        }

        public Task HandleJob(AddReviewJob job, CancellationToken cancellationToken)
        {
            var review = job.State;
            this.storage.StoreAcceptedReview(review);

            return Task.CompletedTask;
        }
    }
}
