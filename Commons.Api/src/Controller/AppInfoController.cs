using System;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Commons.Api.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;

namespace Commons.Api.Controller
{
    [Authorize]
    [Route("api/v1/appinfo")]
    [ApiController]
    public class AppInfoController : AbstractApiController
    {
        private static readonly string _assemblyVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        private readonly ILogger _logger;

        public AppInfoController(ILogger<AppInfoController> logger)
        {
            this._logger = logger;
        }

        [ResponseCache(Duration = 60)]
        [HttpGet]
        public ActionResult<AppInfo> Get()
        {
            var runtimeInfo = PlatformServices.Default.Application.RuntimeFramework;

            return new AppInfo {
                Version = _assemblyVersion,
                Runtime = runtimeInfo.FullName
            };
        }
    }

    public class AppInfo
    {
        public string Version { get; set; }
        public string Runtime { get; set; }
    }
}
