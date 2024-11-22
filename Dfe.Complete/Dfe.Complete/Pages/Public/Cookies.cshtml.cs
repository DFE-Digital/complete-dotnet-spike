using Dfe.Complete.Models;
using Dfe.Complete.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Dfe.Complete.Pages.Public
{
	public class Cookies : PageModel
	{
		public bool? Consent { get; set; }
		public bool PreferencesSet { get; set; } = false;
		public string returnPath { get; set; }
		private readonly ILogger<Cookies> _logger;
		private readonly IAnalyticsConsentService _analyticsConsentService;

		public Cookies(ILogger<Cookies> logger, IAnalyticsConsentService analyticsConsentService)
		{
			_logger = logger;
			_analyticsConsentService = analyticsConsentService;
		}

		public string TransfersCookiesUrl { get; set; }

		public ActionResult OnGet(bool? consent, string returnUrl)
		{
			returnPath = returnUrl;

			Consent = _analyticsConsentService.ConsentValue();

            if (consent.HasValue)
			{
				PreferencesSet = true;

				ApplyCookieConsent(consent.Value);

				if (!string.IsNullOrEmpty(returnUrl))
				{
					return Redirect(returnUrl);
				}

				return RedirectToPage(Links.Public.CookiePreferences);
			}

			return Page();
		}

		public IActionResult OnPost(bool? consent, string returnUrl)
		{
			returnPath = returnUrl;

            Consent = _analyticsConsentService.ConsentValue();

            if (consent.HasValue)
			{
				Consent = consent;
				PreferencesSet = true;

				ApplyCookieConsent(consent.Value);
				return Page();
			}

			return Page();
		}

		private void ApplyCookieConsent(bool consent)
		{
			if (consent) { 
				_analyticsConsentService.AllowConsent();
			}
			else
			{
				_analyticsConsentService.DenyConsent();
			}
		}
	}
}