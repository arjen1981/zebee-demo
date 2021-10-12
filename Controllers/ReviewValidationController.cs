using System.Threading.Tasks;
using Adapters.Generated.Rest.Controllers;
using Adapters.Generated.Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Zeebe.Client;

namespace zeebe_demo.Controllers
{
    public class ReviewValidationController : ReviewsApiController
    {
        private readonly IZeebeClient client;

        public ReviewValidationController(IZeebeClient client)
        {
            this.client = client ?? throw new System.ArgumentNullException(nameof(client));
        }

        public override Task<IActionResult> GetReviews()
        {
            
            throw new System.NotImplementedException();
        }

        public override async Task<IActionResult> ValidateReview([FromBody] RegisterReview registerReview)
        {
            /*await zeebeClient.NewPublishMessageCommand().MessageName("Message_ReviewRecieved")
                .CorrelationKey("1")
                .MessageId("1")
                .Variables(registerReview.ToJson())
                .Send();*/


            await this.client.NewCreateProcessInstanceCommand().BpmnProcessId("Process_ReviewValidation").LatestVersion()
                .Variables(registerReview.ToJson())
                .Send();
            
            return Accepted();
        }
    }
}