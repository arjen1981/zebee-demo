using System.Collections.Generic;
using zebee_demo.Models;

namespace zeebe_demo.Services
{
    public class StorageService
    {
        private readonly List<string> reviews = new List<string>();
        public void StoreAcceptedReview(ProcessState review) => reviews.Add(review.Review);

        public void StoreRejectedReview(ProcessState review)
        {
            if(review.AcceptReview.HasValue && review.AcceptReview == false)
                reviews.Add("Review rejected by moderator");
            else 
                reviews.Add($"Review rejected because sentiment was {review.Sentiment}.");
        }

        public IEnumerable<string> Reviews => reviews;

    }
}
