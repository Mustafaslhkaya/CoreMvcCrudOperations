using CoreMvcCrudOperations.DataAccess;
using CoreMvcCrudOperations.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreMvcCrudOperations.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
        [HttpGet]
        public IActionResult LoginFirst()
        {
            return View();
        }
        public async Task<IActionResult> LoginFirst(Admin admin)
        {
            var info = context.Admins.FirstOrDefault(x => x.AdminName == admin.AdminName && x.AdminPassword == admin.AdminPassword);
            if (info != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.AdminName)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Personel");
            }
            return View();
        }
    }
}
