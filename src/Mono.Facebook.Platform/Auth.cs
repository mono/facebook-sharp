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

			string response = Facebook.Instance.MakeRequest("auth.getSession", parameters);

			if (Facebook.Instance.Format == ResponseType.Json)
			{
				return Facebook.Instance.Serializer.Deserialize<AuthSession>(response);
			}

            throw new NotImplementedException("Looks like that call isn't supported yet");
		}
		#endregion
	}
}

