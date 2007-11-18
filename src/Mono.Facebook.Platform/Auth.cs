using System;
using System.Collections.Generic;

namespace Mono.Facebook.Platform
{
	public class Auth
	{
		#region "Public Static Methods (Facebook)"
		public static AuthSession GetSession(string auth_token)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("auth_token", auth_token);

			return Facebook.Instance.MakeRequest<AuthSession>("auth.getSession", parameters);
		}
		#endregion
	}
}

