using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Applications;
using Solution.CrossCutting.Utils;
using Solution.Model.Models;

namespace Solution.Web.UserInterface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(IAuthenticationApplication authenticationApplication)
        {
            AuthenticationApplication = authenticationApplication;
        }

        private IAuthenticationApplication AuthenticationApplication { get; }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public string Authenticate(AuthenticationModel authentication)
        {
            return AuthenticationApplication.Authenticate(authentication);
        }

        [HttpPost("[action]")]
        public void Logout()
        {
            AuthenticationApplication.Logout(User.GetAuthenticatedUserId());
        }
    }
}
