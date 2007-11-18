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

			return Facebook.Instance.MakeRequest<bool>("profile.setFBML", parameters);
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

			return Facebook.Instance.MakeRequest<string>("profile.getFBML", parameters);
		}
        #endregion
    }
}
