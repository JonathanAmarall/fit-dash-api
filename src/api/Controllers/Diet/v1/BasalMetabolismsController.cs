using FitDash.Core.Mediator;
using FitDash.Diet.Domain.Commands;
using FitDash.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FitDash.Api.Controllers.Diet.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasalMetabolismsController : MainController
    {
        private readonly IMediatorHandler mediator;

        public BasalMetabolismsController(IMediatorHandler mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public ActionResult Get() => Ok();

        [HttpPost]
        public async Task<ActionResult> Create(CreateBasalMetabolismCommand command)
        {
            var result = await mediator.SendCommand(command);

            if (!result.IsValid)
                result.Errors.ForEach(error => AddProcessingError(error.ErrorMessage));

            return CustomReponse();
        }
    }
}
