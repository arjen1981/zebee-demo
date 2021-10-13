using System.Collections.Generic;
using zebee_demo;

namespace zeebe_demo
{
    public class StorageService
    {
        public List<ProcessState> acceptedReviews = new List<ProcessState>();
        public List<ProcessState> rejectedReviews = new List<ProcessState>();

        public void StoreAcceptedReview(ProcessState review)
        {
            acceptedReviews.Add(review);
        }

        public void StoreRejectedReview(ProcessState review)
        {
            rejectedReviews.Add(review);
        }

    }
}
