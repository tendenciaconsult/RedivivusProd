using Simir.CrossCutting.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Simir.CrossCutting.Security.ViewModels;
using System.Security.Claims;
using Simir.Domain.Entities;
using System;

namespace Simir.WebInterfaceComAuth.Areas.Identificacao.Controllers
{
    [Authorize]
    public class AutenticacaoController : Controller
    {
        public AutenticacaoController()
        {
        }
        //*
        public AutenticacaoController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
         //*/

        // Definindo a instancia UserManager presente no request.
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // Definindo a instancia SignInManager presente no request.
        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }


        [AllowAnonymous]
        public async Task<ActionResult> ConfigurarConta()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            if(user.TBUsuario != null){
                return RedirectToAction("Editar", "Usuario", new { area = "Configuracao" });
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult NaoAutorizado()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Logar(string returnUrl)
        {

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Identificacao/Autenticacao/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Logar(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: true);
            switch (result)
            {
                case SignInStatus.Success:
                    var user = await UserManager.FindAsync(model.Email, model.Password);
                    if (!user.EmailConfirmed)
                    {
                        TempData["AvisoEmail"] = "Usuário não confirmado, verifique seu e-mail.";
                    }
                    await SignInAsync(user, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Login ou Senha incorretos.");
                    return View(model);
            }
        }
        private async Task SignInAsync(AspNetUser user, bool isPersistent)
        {
            var clientKey = Request.Browser.Type;// +Request.Headers["X-NuGet-ApiKey"];
            await UserManager.SignInClientAsync(user, clientKey);
            // Zerando contador de logins errados.
            await UserManager.ResetAccessFailedCountAsync(user.Id);

            // Coletando Claims externos (se houver)
            ClaimsIdentity ext = await AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie);
            // Criação da instancia do Identity e atribuição dos Claims
            var claims = await user.GenerateUserIdentityAsync(UserManager, ext);
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(
                    new AuthenticationProperties { IsPersistent = isPersistent },
                    claims
                );
        }


        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Registrar()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registrar(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AspNetUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmaEmail", "Autenticacao", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Confirme sua Conta", "Por favor confirme sua conta clicando neste link: <a href='" + callbackUrl + "'></a>");
                    ViewBag.Link = callbackUrl;
                    return View("DisplayEmail");
                }
                AddErrors(result);
            }

            // No caso de falha, reexibir a view. 
            return View(model);
        }
        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmaEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmaEmail" : "Error");
        }


        #region Esqueceu senha
        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult EsqueceuSenha()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EsqueceuSenha(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Não revelar se o usuario nao existe ou nao esta confirmado
                    return View("EsqueceuSenhaConfirmacao");
                }

                var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("RedefinirSenha", "Autenticacao", new { area = "Identificacao", userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Esqueci minha senha", callbackUrl+ " Por favor altere sua senha clicando aqui: <a href='" + callbackUrl + "'></a>");
                ViewBag.Link = callbackUrl;
                ViewBag.Status = "DEMO: Caso o link não chegue: ";
                ViewBag.LinkAcesso = callbackUrl;
                return View("EsqueceuSenhaConfirmacao");
            }

            // No caso de falha, reexibir a view. 
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult EsqueceuSenhaConfirmacao()
        {
            return View();
        }

        #endregion

        #region Alterar Senha

        [AllowAnonymous]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AlterarSenha(AlterarSenhaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.Password);
            
            if (result.Succeeded)
            {
                return RedirectToAction("AlterarSenhaConfirmacao", "Autenticacao", new { area = "Identificacao" });
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult AlterarSenhaConfirmacao()
        {
            return View();
        }
        #endregion


        #region Redefinir Senha
        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult RedefinirSenha(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RedefinirSenha(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Não revelar se o usuario nao existe ou nao esta confirmado
                return RedirectToAction("RedefinirSenhaConfirmacao", "Autenticacao", new { area = "Identificacao" });
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("RedefinirSenhaConfirmacao", "Autenticacao", new { area = "Identificacao" });
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult RedefinirSenhaConfirmacao()
        {
            return View();
        }

        #endregion




        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "SimirXsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        #endregion
        
        
        private async Task SignOutAsync()
        {
            var clientKey = Request.Browser.Type;
            var user = UserManager.FindById(User.Identity.GetUserId());
            await UserManager.SignOutClientAsync(user, clientKey);
            
            AuthenticationManager.SignOut();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeslogarTodos(string funcao)
        {
            if (string.IsNullOrWhiteSpace(funcao))
            {
                UserManager.UpdateSecurityStamp(User.Identity.GetUserId());
                await SignOutAsync();
            }
            else
            {
                var user = UserManager.FindById(User.Identity.GetUserId());
                await UserManager.TrocarFuncao(user, funcao);
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}