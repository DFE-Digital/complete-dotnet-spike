using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;

namespace Dfe.Complete.Services
{
    public interface IAnalyticsConsentService
    {
        void AllowConsent();
        bool? ConsentValue();
        void DenyConsent();
        bool HasConsent();
    }

    public class AnalyticsConsentService : IAnalyticsConsentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string ConsentCookieName = ".ManageFreeSchoolProjects.Consent";
        private bool? Consent { get; set; }
        private string AnalyticsDomain = ".education.gov.uk";

        public AnalyticsConsentService(IHttpContextAccessor httpContextAccessor, IConfiguration _configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            var domain = _configuration["GoogleAnalytics:Domain"];
            if (!string.IsNullOrEmpty(domain))
            {
				AnalyticsDomain = domain;
			}
		}

        public bool? ConsentValue()
        {
            if (Consent.HasValue)
            {
                return Consent;
            }

            if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(ConsentCookieName))
            {
                return bool.Parse(_httpContextAccessor.HttpContext.Request.Cookies[ConsentCookieName]);
            }

            return false;
        }

        public bool HasConsent()
        {
            return ConsentValue() ?? false;
        }

        public void AllowConsent()
        {
            SetConsent(true);
        }

        public void DenyConsent()
        {
            SetConsent(false);
        }

        private void SetConsent(bool consent)
        {
            Consent = consent;
            var cookieOptions = new CookieOptions { Expires = DateTime.Today.AddMonths(6), Secure = true, HttpOnly = true };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(ConsentCookieName, consent.ToString(), cookieOptions);
            var request = _httpContextAccessor.HttpContext.Request;

			if (!consent)
            {
                foreach (var cookie in request.Cookies.Keys)
                {
                    if (cookie.StartsWith("_ga") || cookie.Equals("_gid"))
                    {
                        //Delete if domain is the same
						_httpContextAccessor.HttpContext.Response.Cookies.Delete(cookie);
                        //Delete if domain matches - need both as we wont be sent the cookie if the domain doesnt match
						_httpContextAccessor.HttpContext.Response.Cookies.Delete(cookie, new CookieOptions() { Domain = AnalyticsDomain});
					}
                }
            }
        }
    }

}