using System.Threading.Tasks;
using Adapters.Rest.Generated.Controllers;
using Adapters.Rest.Generated.Models;
using Microsoft.AspNetCore.Mvc;
using zebee_demo;
using Zeebe.Client;
using Zeebe.Client.Bootstrap.Abstractions;

namespace zeebe_demo.Controllers
{
    public class ReviewValidationController : ReviewsApiController
    {
        private readonly IZeebeClient client;
        private readonly IZeebeVariablesSerializer serializer;

        public ReviewValidationController(IZeebeClient client, IZeebeVariablesSerializer serializer)
        {
            this.client = client ?? throw new System.ArgumentNullException(nameof(client));
            this.serializer = serializer ?? throw new System.ArgumentNullException(nameof(serializer));
        }

        public override Task<IActionResult> GetReviews()
        {
            
            throw new System.NotImplementedException();
        }

        public override async Task<IActionResult> ValidateReview([FromBody] RegisterReview registerReview)
        {
            var state = new ProcessState()
            {
                Review = registerReview.Review
            };

            await this.client.NewCreateProcessInstanceCommand()
                .BpmnProcessId("Process_ReviewValidation").LatestVersion()
                .Variables(serializer.Serialize(state))
                .Send();
            
            return Accepted();
        }
    }
}