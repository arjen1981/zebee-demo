using System.Threading.Tasks;
using Adapters.Rest.Generated.Controllers;
using Adapters.Rest.Generated.Models;
using Microsoft.AspNetCore.Mvc;
using Zeebe.Client;
using Zeebe.Client.Bootstrap.Abstractions;
using zeebe_demo.Services;

namespace zeebe_demo.Controllers
{
    public class ReviewValidationController : ReviewsApiController
    {
        private readonly IZeebeClient client;
        private readonly IZeebeVariablesSerializer serializer;
        private readonly StorageService storage;

        public ReviewValidationController(IZeebeClient client, IZeebeVariablesSerializer serializer, StorageService storage)
        {
            this.client = client ?? throw new System.ArgumentNullException(nameof(client));
            this.serializer = serializer ?? throw new System.ArgumentNullException(nameof(serializer));
            this.storage = storage ?? throw new System.ArgumentNullException(nameof(storage));
        }

        public override Task<IActionResult> GetReviews() => Task.FromResult<IActionResult>(
            Ok(storage.Reviews)
        );

        public override async Task<IActionResult> ValidateReview([FromBody] RegisterReview registerReview)
        {
            await this.client.NewCreateProcessInstanceCommand()
                .BpmnProcessId("Process_ReviewValidation").LatestVersion()
                .Variables(serializer.Serialize(new { registerReview.Review }))
                .Send();
            
            return Accepted();
        }
    }
}