using System;
using Commons.Api.FlashScope;
using Commons.Api.Messages;
using Commons.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Commons.Api.Controller
{
    public abstract class AbstractMvcController : Microsoft.AspNetCore.Mvc.Controller
    {
        protected readonly ILogger _logger;
        protected readonly IFlashService _flash;
        protected readonly IMessageIntegrity _messageIntegrity;

        public AbstractMvcController(ILogger<AbstractMvcController> logger,
            IFlashService flash, IMessageIntegrity messageIntegrity)
        {
            _logger = logger;
            _flash = flash;
            _messageIntegrity = messageIntegrity;
        }

        protected virtual ActionResult PrepareErrorResult(string key)
        {
            var message = "An error occured!";
            if (!string.IsNullOrEmpty(key))
            {
                if (_messageIntegrity.Verify(key))
                {
                    message = _flash.Get(key);
                }
            }
            return View(new MessageContainer
            {
                Error = message,
                Success = ""
            });
        }

        /// <summary>
        /// display an error
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("error/{key?}")]
        [AllowAnonymous]
        public ActionResult Error(string key)
        {
           return PrepareErrorResult(key);
        }
    }
}
