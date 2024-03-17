using LearnHub.Email;
using LearnHub.Email.Features.Requests.Commands;
using LearnHub.Email.Model;
using LearnHub.Identity.Features.Login.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestForEmailController : ControllerBase
    {

        private readonly IEmailService _emailService;
        private readonly IMediator _mediator;
        public TestForEmailController(IEmailService emailService, IMediator mediator)
        {
            _emailService = emailService;
            _mediator = mediator;
        }


        [HttpPost("med")]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }



        [HttpPost("withMed")]
        public async Task<IActionResult> SendEmail_2(EmailDto request)
        {
            var responce = await _mediator.Send(new SendEmail_R { email = request });
            return Ok(responce);
        }
    }
}
