using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OAuth.Controllers
{
    [AllowAnonymous, Route("account")]          // Added code
    public class AccountController : Controller
    {
        [Route("google-login")]                 // Added code
        public IActionResult GoogleLogin()      // Changed the Index() to GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };       // getting a Uri mismatch for some reason

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [Route("google-response")]              // This code corresponds to Route("account") added code 
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities.FirstOrDefault()
                .Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });

            return Json(claims);
        }
    }
}
