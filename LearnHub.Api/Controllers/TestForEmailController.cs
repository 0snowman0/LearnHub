using LearnHub.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestForEmailController : ControllerBase
    {
        [HttpGet]
        public ActionResult SendEmail()
        {
            string subject = "موضوع ایمیل";
            string message = "متن ایمیل";
            string to = "آدرس ایمیل گیرنده";

            LocalMailService service = new LocalMailService();
            service.Send(subject, message);
            
            return Ok("done");
        }
    }
}
