namespace zeebe_demo
{
    public class SentimentResult
    {
        public enum TextSentiment
        {
            Positive,
            Neutral,
            Negative,
            Mixed
        }

        public TextSentiment Sentiment { get; set; }
    }
}