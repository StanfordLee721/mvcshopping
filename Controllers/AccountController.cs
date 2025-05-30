
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcshopping.Models;
using Microsoft.AspNetCore.Identity;
using mvcshopping.Models.Tables; // 引入BCrypt.Net命名空間

namespace mvcshopping.Controllers
{
    public class AccountController : Controller
    {
        private readonly dbEntities _context;
        // private readonly SignInManager<Users> _signInManager;

        public AccountController(dbEntities context)
        {
            _context = context;
        }

        //註冊頁面--連接至前端註冊頁面
        [HttpGet]
        public IActionResult Register()
        {
            var model = new Users
            {
                UserName = string.Empty,
                Password = string.Empty,
                Email = string.Empty
            }; // 確保 Model 被初始化
            return View(model);

        }


        //註冊處理--實際處理Register()時要做的事
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Users user)
        {
            //自動驗證資料格式是否正確
            if (ModelState.IsValid)
            {
                //檢查用戶名稱是否存在
                if (_context.Users.Any(u => u.UserName == user.UserName))
                {
                    ModelState.AddModelError("Username", "用戶名稱已被使用");
                }
                //檢查電子郵件是否存在
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Username", "電子郵件已被使用");
                }
                // 註冊時加密密碼
                user.Password = HashPassword(user.Password);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // 註冊後自動登入
                await SignInUser(user);

                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        // 密碼加密--使用BCrypt.Net進行密碼加密
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // 驗證密碼是否正確
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        //登入頁面--連接至前端登入頁面
        [HttpGet]
        public IActionResult Login()
        {
            var username = User.Identity.IsAuthenticated ? User.Identity.Name : "未登入";
            ViewBag.UserName = username;
            Console.WriteLine($"登入狀態：{User.Identity.IsAuthenticated}, 使用者名稱：{username}");
            return View();
        }
        //登入處理--實際處理Login()時要做的事
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "帳號或密碼錯誤");
                return View();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (!string.IsNullOrEmpty(user.Password))
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (user == null || !isPasswordValid)
                {
                    ModelState.AddModelError("", "帳號或密碼錯誤");
                    return View();
                }

            }
            // 更新最後登入時間
            user.LastLogin = DateTime.Now;
            _context.Update(user);
            Console.WriteLine("使用者:" + user.UserName + "登入時間:" + user.LastLogin);
            await _context.SaveChangesAsync();

            await SignInUser(user);

            return RedirectToAction("Index", "Home");
        }

        //登出
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        //用戶登入方法
        private async Task SignInUser(Users user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = true // 記住我
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
        }
        // [HttpGet]
        // public IActionResult TestBCrypt()
        // {
        //     string hashedPassword = BCrypt.Net.BCrypt.HashPassword("user123");

        //     Console.WriteLine($"原始字串: user123");
        //     Console.WriteLine($"加密後的結果: {hashedPassword}");

        //     return Content($"原始字串: user123\n加密後的結果: {hashedPassword}");
        // }


    }
}