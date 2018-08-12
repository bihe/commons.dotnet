using System;
using Commons.Api.FlashScope;
using Commons.Api.Messages;
using Commons.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Commons.Api.Controller
{
    public class ErrorController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger logger;
        private IFlashService flash;
        private IMessageIntegrity messageIntegrity;

        public ErrorController(ILogger<ErrorController> logger,
            IFlashService flash, IMessageIntegrity messageIntegrity)
        {
            this.logger = logger;
            this.flash = flash;
            this.messageIntegrity = messageIntegrity;
        }

        /// <summary>
        /// display an error
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("error/{key?}")]
        [AllowAnonymous]
        public IActionResult Error(string key)
        {
            var message = "An error occured!";
            if (!string.IsNullOrEmpty(key))
            {
                if (this.messageIntegrity.Verify(key))
                {
                    message = this.flash.Get(key);
                }
            }
            return View(new MessageContainer
            {
                Error = message,
                Success = ""
            });
        }
    }
}
