using System;

namespace Mono.Facebook.Platform
{
    public class FBML
    {
		#region "Public Static Methods (Facebook)"
		public static bool RefreshImgSrc(string url)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("url", url);

			return Facebook.Instance.MakeRequest<bool>("fbml.refreshImgSrc", parameters);
		}

		public static bool RefreshRefUrl(string url)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("url", url);

			return Facebook.Instance.MakeRequest<bool>("fbml.refreshRefUrl", parameters);
		}

		public static bool SetRefHandle(string handle, string markup)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("handle", handle);
			parameters.Add("fbml", markup);

			return Facebook.Instance.MakeRequest<bool>("fbml.setRefHandle", parameters);
		}
        #endregion
    }
}
