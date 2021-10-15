using System.Collections.Generic;

namespace zeebe_demo.Services
{
    public class StorageService
    {
        private readonly List<string> reviews = new List<string>();
        public void StoredReview(string review) => reviews.Add(review);
        public IEnumerable<string> Reviews => reviews;

    }
}
