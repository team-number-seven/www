using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace www.Backend.IdentityServer.Controllers;

[Controller]
[AllowAnonymous]
[Route("[controller]")]
public class DevController : Controller
{
    
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Home()
    {
        return View("Home");
    }
}