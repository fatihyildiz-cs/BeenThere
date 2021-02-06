using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeenThere1.Business.Abstract;
using BeenThere1.Entity;
using BeenThere1.WebUI.EmailServices;
using BeenThere1.WebUI.Identity;
using BeenThere1.WebUI.Models;
using Bia.Countries.Iso3166;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeenThere1.WebUI.Controllers
{
    public class AccountController : Controller
    {
        // service for create/delete user, forgot password etc.
        private readonly UserManager<BeenThereUser> _UserManager;
        //service for cookie arrangements
        private readonly SignInManager<BeenThereUser> _SignInManager;

        private readonly IEmailSender _EmailSender;

        public AccountController(UserManager<BeenThereUser> userManager,
                                 SignInManager<BeenThereUser> signInManager,
                                 IEmailSender emailSender)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
            _EmailSender = emailSender;
        }

        // GET: /<controller>/

        public IActionResult Index()
        {
            return View();
        }

        //users who try to reach an authorized area are directed to the login page with a return url.
        //we should keep this url (send it to view) and redirect the user to it once login is succesfull.
        //returnUrl is made nullable because users may directly use the path /account/login (that means there
        //is no returnUrl to be passed.)

        [HttpGet]
        public IActionResult Login(string popup, string returnUrl=null)
        {
            var model = new LoginModel()
            {
                ReturnUrl = returnUrl,
                Popup = popup
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByNameAsync(model.UserName);

                if (user == null)
                {
                    ModelState.AddModelError("", "User not found.");
                    return View(model);
                }

                if(! await _UserManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("", "Please confirm your account from the link in your inbox.");
                    return View(model);
                }

                var result = await _SignInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    //check if the return url is empty. if so, redirect to homepage.
                    return Redirect(model.ReturnUrl ?? "~/");
                }

                ModelState.AddModelError("", "Wrong password.");
                return View(model);

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if(await _UserManager.FindByNameAsync(model.UserName) != null)
                {
                    ModelState.AddModelError("", "Username already in use.");
                }
                if (await _UserManager.FindByEmailAsync(model.Email) != null)
                {
                    ModelState.AddModelError("", "Email already in use.");
                }

                var user = new BeenThereUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email,
                    VisitedCountryCodesList = "",
                    ProfilePicUrl = "defaultProfilePic.jpg"
                };
                if(model.Password == model.RePassword)
                {
                    var result = await _UserManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        // generate token
                        var code = await _UserManager.GenerateEmailConfirmationTokenAsync(user);
                        var url = Url.Action("ConfirmEmail", "Account", new
                        {
                            userId = user.Id,
                            token = code
                        });

                        // email
                        await _EmailSender.SendEmailAsync(model.Email, "Confirm your BeenThere account.",
                            $"Please confirm your account by clicking <a href='https://localhost:5001{url}'>this link</a>.");
                        return RedirectToAction("Login", "Account", new { popup = "IsNewAccount" });
                    }
                        ModelState.AddModelError("", "Password should be at least 6 characters long and should contain at least one lowercase, one uppercase, one digit and one special character.");
                }
                else
                {
                    ModelState.AddModelError("", "Passwords don't match.");
                }
                return View(model);
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();

            return Redirect("~/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId==null || token == null)
            {
                return View();
            }
            var user = await _UserManager.FindByIdAsync(userId);
            if(user != null)
            {
                var result = await _UserManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    return Redirect("/account/login");
                }
            }
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return View();
            }

            var user = await _UserManager.FindByEmailAsync(Email);

            if (user == null)
            {
                return View();
            }

            var code = await _UserManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });

            // send email
            await _EmailSender.SendEmailAsync(Email, "Reset your BeenThere password", $"To reset your BeenThere password, please click <a href='https://localhost:5001{url}'>this link</a>.");

            return RedirectToAction("Login", "Account", new { popup = "PasswordReset" });
        }

        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Home", "Index");
            }

            var model = new ResetPasswordModel { Token = token };

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return View(model);
            }

            var result = await _UserManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account", new { popup = "PasswordResetSuccessfull" });
            }

            return View(model);
        }


        public IActionResult Manage()
        {

            return View();
        }

    }
}
