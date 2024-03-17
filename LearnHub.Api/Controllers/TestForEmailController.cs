using LearnHub.Email;
using LearnHub.Email.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestForEmailController : ControllerBase
    {

        private readonly IEmailService _emailService;

        public TestForEmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
    }
}
