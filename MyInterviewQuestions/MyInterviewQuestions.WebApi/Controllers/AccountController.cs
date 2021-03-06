﻿using Microsoft.AspNet.Identity;
using MyInterviewQuestions.Core;
using MyInterviewQuestions.Service;
using MyInterviewQuestions.WebApi.Framework;
using MyInterviewQuestions.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyInterviewQuestions.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private readonly ApplicationUserManager _userManager;
        private readonly IEncryptionService _encryptionService;

        public AccountController(ApplicationUserManager userManager,IEncryptionService encryptionService)
        {
            _userManager = userManager;
            _encryptionService = encryptionService;
        }

        // /api/Account/Register
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                User user = new User() { UserName = userModel.UserName };

                string saltKey = _encryptionService.CreateSaltKey(5);
                user.PasswordSalt = saltKey;
                user.PasswordHash = _encryptionService.CreatePasswordHash(userModel.Password, saltKey);

                IdentityResult result = await _userManager.CreateAsync(user);

                if (!result.Succeeded)
                    return GetErrorResult(result);

                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region Helpers
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
        #endregion Helpers
    }
}
