using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SimpleSevenWonders.Models
{
	public static class IdentityHelper
	{
		// Used for XSRF when linking external logins
		public const string XsrfKey = "XsrfId";

		public const string ProviderNameKey = "providerName";

		public static ApplicationUser GetApplicationUser()
		{
			using (var db = new ApplicationDbContext())
			{
				using (var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)))
				{
					return userManager.FindById(HttpContext.Current.User.Identity.GetUserId());
				}
			}
		}

		public static bool IsWondersAdmin()
		{
			var user = GetApplicationUser();
			return user != null && user.WondersAdmin;
		}
		public static string GetProviderNameFromRequest(HttpRequest request)
		{
			return request.QueryString[ProviderNameKey];
		}

		public const string CodeKey = "code";
		public static string GetCodeFromRequest(HttpRequest request)
		{
			return request.QueryString[CodeKey];
		}

		public const string UserIdKey = "userId";
		public static string GetUserIdFromRequest(HttpRequest request)
		{
			return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
		}

		public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
		{
			var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
			return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
		}

		public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
		{
			var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
			return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
		}

		private static bool IsLocalUrl(string url)
		{
			return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
		}

		public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
		{
			if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
			{
				response.Redirect(returnUrl);
			}
			else
			{
				response.Redirect("~/");
			}
		}
	}
}