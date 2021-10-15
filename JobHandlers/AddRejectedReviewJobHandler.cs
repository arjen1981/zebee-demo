using System.Threading;
using System.Threading.Tasks;
using Zeebe.Client.Bootstrap.Abstractions;
using zeebe_demo.Jobs;
using zeebe_demo.Services;

namespace zeebe_demo.JobHandlers
{
    public class AddRejectedReviewJobHandler : IAsyncJobHandler<AddRejectedReviewJob>
    {
        private readonly StorageService storage;

        public AddRejectedReviewJobHandler(StorageService storage)
        {
            this.storage = storage ?? throw new System.ArgumentNullException(nameof(storage));
        }

        public Task HandleJob(AddRejectedReviewJob job, CancellationToken cancellationToken)
        {
            if(job.State.ValidationResult?.Equals("Rejected") == true)
                this.storage.StoredReview("Review rejected by moderator");
            else 
                this.storage.StoredReview($"Review rejected because sentiment was {job.State.Sentiment}.");

            return Task.CompletedTask;
        }
    }
}
