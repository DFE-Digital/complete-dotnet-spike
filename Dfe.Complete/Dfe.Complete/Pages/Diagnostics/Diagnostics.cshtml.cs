using Dfe.Complete.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace Dfe.Complete.Pages.Diagnostics
{
    public class DiagnosticsModel : PageModel
    {
		private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public string Env { get; set; }
        public string ReleaseTag { get; set; }

        public string ModuleVersionId { get; set; }
        public Version AssemblyVersion { get; set; }
        public string AssemblyFileVersion { get; set; }
        public string AssemblyInformationalVersion { get; set; }
        public string BuildGuid { get; set; }
        public string BuildTime { get; set; }
        public string BuildMode { get; set; }
        public string BuildMessage { get; set; }

        public DiagnosticsModel(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        public void OnGet()
        {
            ReleaseTag = _configuration["Dfe.Complete:ReleaseTag"];

            if (_env.IsDevelopment() || _env.IsStaging())
            {
                this.Env = _env.IsDevelopment() ? "Development" : "Staging";
            }

            var assembly = Assembly.GetEntryAssembly();
            AssemblyVersion = assembly.GetName().Version;
            AssemblyFileVersion = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
            AssemblyInformationalVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            ModuleVersionId = assembly.ManifestModule.ModuleVersionId.ToString();
            BuildMode = GetBuildMode();
            BuildTime = assembly.GetCustomAttribute<BuildTimeAttribute>().BuildTime;
            BuildGuid = assembly.GetCustomAttribute<BuildGuidAttribute>().BuildGuid;
            BuildMessage = assembly.GetCustomAttribute<CustomBuildMessageAttribute>().CustomBuildMessage;
        }

        public string[] Roles { get; set; }

        private string GetBuildMode()
        {
#if DEBUG
            return "DEBUG";
#else
	return "RELEASE";
#endif

        }
    }
}

