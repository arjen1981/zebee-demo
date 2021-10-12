using System.Threading;
using System.Threading.Tasks;
using Zeebe.Client.Bootstrap.Abstractions;
using zeebe_demo.Jobs;
using Azure;
using Azure.AI.TextAnalytics;
using System;

namespace zeebe_demo.JobHandlers
{
    public class AnalyzeSentimentJobHandler : IAsyncJobHandler<AnalyzeSentimentJob, SentimentResult>
    {
        public async Task<SentimentResult> HandleJob(AnalyzeSentimentJob job, CancellationToken cancellationToken)
        {
            var client = new TextAnalyticsClient(
                new Uri("https://sentiment-cog.cognitiveservices.azure.com/"),
                new AzureKeyCredential("cd24d23f33794a2cb1495a8371011f8a"));

            DocumentSentiment documentSentiment = await client.AnalyzeSentimentAsync(job.Variables);

            return new SentimentResult
            {
                Sentiment = (SentimentResult.TextSentiment)documentSentiment.Sentiment
            };
        }
    }
}
