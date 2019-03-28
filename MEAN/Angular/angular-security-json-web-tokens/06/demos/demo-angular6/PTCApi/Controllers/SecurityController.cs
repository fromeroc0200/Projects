using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PtcApi.Security;
using PtcApi.Model;

namespace PtcApi.Controllers
{
  [Route("api/[controller]")]
  public class SecurityController : Controller
  {
    private JwtSettings _settings;
    public SecurityController(JwtSettings settings)
    {
      _settings = settings;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody]AppUser user)
    {
      IActionResult ret = null;
      AppUserAuth auth = new AppUserAuth();
      SecurityManager mgr = new SecurityManager(_settings);

      auth = mgr.ValidateUser(user);
      if (auth.IsAuthenticated)
      {
        ret = StatusCode(StatusCodes.Status200OK, auth);
      }
      else
      {
        ret = StatusCode(StatusCodes.Status404NotFound,
                         "Invalid User Name/Password.");
      }

      return ret;
    }
  }
}
