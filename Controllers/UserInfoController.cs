using Microsoft.AspNetCore.Mvc;
using dermal.api.Models;
using Microsoft.AspNetCore.Identity;

namespace dermal_api.Controllers
{
    [Produces("application/json")]
    [Route("api/UserInfo")]
    public class UserInfoController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;


        public UserInfoController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        //[HttpGet , Produces("application/json")]
        //public async Task<IActionResult> UserInfo() {
        //    var user = await userManager.GetUserAsync(User);
        //    if (user == null) {
        //        return BadRequest(new OpenIdConnectResponse {
        //            Error = OpenIdConnectConstants.Errors.InvalidGrant,
        //            ErrorDescription = "The user profile is no longer available."
        //        });
        //    }

        //    var claims = new JObject();
        //    claims[OpenIdConnectConstants.Claims.Subject] = await this.userManager.GetUserIdAsync(user);

        //    if(User.HasClaim(OpenIdConnectConstants.Claims.Scope, OpenIdConnectConstants.Scopes.Email)

        //}

    }
}