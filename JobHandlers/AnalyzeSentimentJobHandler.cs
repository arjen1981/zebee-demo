using System.Threading;
using System.Threading.Tasks;
using Zeebe.Client.Bootstrap.Abstractions;
using zeebe_demo.Jobs;
using Azure;
using Azure.AI.TextAnalytics;
using System;
using zebee_demo.Models;

namespace zeebe_demo.JobHandlers
{
    public class AnalyzeSentimentJobHandler : IAsyncJobHandler<AnalyzeSentimentJob, ProcessState>
    {
        public async Task<ProcessState> HandleJob(AnalyzeSentimentJob job, CancellationToken cancellationToken)
        {
            var state = job.State;

            var client = new TextAnalyticsClient(
                new Uri("https://sentiment-cog.cognitiveservices.azure.com/"),
                new AzureKeyCredential("cd24d23f33794a2cb1495a8371011f8a"));

            // Todo Exception (no internet)
            // Todo How to triger mixed or neutral with TextAnalyticsClient

            var response = await client.AnalyzeSentimentAsync(state.Review);

            return new ProcessState()
            {
                Sentiment = response.Value.Sentiment.ToString()
            };
        }
    }
}
