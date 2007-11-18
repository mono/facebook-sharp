using System;
using System.Collections.Generic;

namespace Mono.Facebook.Platform
{
    public class Notifications
    {
		#region "Public Static Methods (Facebook)"
		public static void Get()
		{
			string response = Facebook.Instance.MakeRequest<string>("notifications.get");

			Console.WriteLine(response);
        }

		public static bool Send(string markup, Int64[] uids)
		{
			return Notifications.Send(markup, new List<Int64>(uids));
		}
		public static bool Send(string markup, List<Int64> uids)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			string[] _uids = Array.ConvertAll<Int64, string>(uids.ToArray(), delegate(Int64 uid) { return uid.ToString(); });

			parameters.Add("notification", markup);
			parameters.Add("to_ids", String.Join(",", _uids));

			return Facebook.Instance.MakeRequest<bool>("notifications.send", parameters);
		}
		#endregion
    }
}
