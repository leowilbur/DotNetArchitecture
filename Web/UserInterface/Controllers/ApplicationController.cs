using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Model.Models;

namespace Solution.Web.UserInterface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(Duration = 1440)]
        public ApplicationModel Get()
        {
            return new ApplicationModel();
        }
    }
}
