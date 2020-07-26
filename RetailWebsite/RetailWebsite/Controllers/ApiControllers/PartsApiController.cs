using Microsoft.AspNetCore.Mvc;
using Models.Request;

namespace RetailWebsite.Controllers.ApiControllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartsApiController : ControllerBase
    {

        [HttpPost("ConfirmPartsOrder")]
        public bool ConfirmPartsOrder(PartsOrderRequest request)
        {
            return true;
        }
    }
}