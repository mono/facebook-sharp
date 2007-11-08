using System;
using System.Collections.Generic;

namespace Mono.Facebook.Platform
{
    public class Profile
    {
		#region "Public Static Methods (Facebook)"
		public static bool SetFbml(string markup)
		{
			return Profile.SetFbml(markup, -1);
		}
		public static bool SetFbml(string markup, Int64 uid)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();

			parameters.Add("markup", markup);
			if (uid > 0)
				parameters.Add("uid", uid.ToString());

			string response = Facebook.Instance.MakeRequest("profile.setFBML", parameters);

			if (Facebook.Instance.Format == ResponseType.Json)
			{
				return Facebook.Instance.Serializer.Deserialize<bool>(response);
			}

            throw new NotImplementedException("Looks like that call isn't supported yet");
		}

		public static string GetFbml()
		{
			return Profile.GetFbml(-1);
		}
		public static string GetFbml(Int64 uid)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			if (uid > 9)
				parameters.Add("uid", uid.ToString());

			string response = Facebook.Instance.MakeRequest("profile.getFBML", parameters);
			
			if (Facebook.Instance.Format == ResponseType.Json)
			{
				return Facebook.Instance.Serializer.Deserialize<String>(response);
			}

            throw new NotImplementedException("Looks like that call isn't supported yet");
		}
        #endregion
    }
}
