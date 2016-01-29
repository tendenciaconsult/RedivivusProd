﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Simir.Domain.Entities;

namespace Simir.CrossCutting.Security
{
    // Validação do Secutiry Stamp para usuário conectado nos clients registrados.
    public static class ApplicationCookieIdentityValidator
    {
        private static async Task<bool> VerifySecurityStampAsync(ApplicationUserManager manager, AspNetUser user,
            CookieValidateIdentityContext context)
        {
            var stamp = context.Identity.FindFirstValue("AspNet.Identity.SecurityStamp");
            return (stamp == await manager.GetSecurityStampAsync(context.Identity.GetUserId()));
        }

        private static Task<bool> VerifyClientIdAsync(ApplicationUserManager manager, AspNetUser user,
            CookieValidateIdentityContext context)
        {
            var clientId = context.Identity.FindFirstValue("AspNet.Identity.ClientId");
            if (!string.IsNullOrEmpty(clientId) && user.Clients.Any(c => c.Id.ToString() == clientId))
            {
                user.CurrentClientId = clientId;
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        //mudei!!!!
        public static Func<CookieValidateIdentityContext, Task> OnValidateIdentity(TimeSpan validateInterval,
            Func<ApplicationUserManager, AspNetUser, Task<ClaimsIdentity>> regenerateIdentity)
        {
            return async context =>
            {
                var utcNow = context.Options.SystemClock.UtcNow;
                var issuedUtc = context.Properties.IssuedUtc;
                var expired = false;
                if (issuedUtc.HasValue)
                {
                    var t = utcNow.Subtract(issuedUtc.Value);
                    expired = (t > validateInterval);
                }
                if (expired)
                {
                    var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
                    var userId = context.Identity.GetUserId();
                    if (userManager != null && userId != null)
                    {
                        var user = await userManager.FindByIdAsync(userId);
                        var reject = true;
                        if (user != null
                            && await VerifySecurityStampAsync(userManager, user, context)
                            && await VerifyClientIdAsync(userManager, user, context))
                        {
                            reject = false;
                            if (regenerateIdentity != null)
                            {
                                var claimsIdentity = await regenerateIdentity(userManager, user);
                                if (claimsIdentity != null)
                                {
                                    context.OwinContext.Authentication.SignIn(claimsIdentity);
                                }
                            }
                        }
                        if (reject)
                        {
                            context.RejectIdentity();
                            context.OwinContext.Authentication.SignOut(context.Options.AuthenticationType);
                        }
                    }
                }
            };
        }
    }
}