using LearnHub.Identity.IdentityService.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers.Financial
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentGatewayController : ControllerBase
    {
        private readonly IUserService _userservice;

        public PaymentGatewayController(IUserService userservice)
        {
            _userservice = userservice;
        }





    }
}
