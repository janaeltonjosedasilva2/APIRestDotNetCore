using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api_rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeControllet : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        [AllowAnonymous]
        public dynamic Get()
        {
            return new {Message = "Welcome to API"};
        }
    }
}
