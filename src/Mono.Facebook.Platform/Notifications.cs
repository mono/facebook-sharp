using System;
using System.Collections.Generic;

namespace Mono.Facebook.Platform
{
    public class Notifications
    {
		#region "Public Static Methods (Facebook)"
		public static void Get()
		{
			string response = Facebook.Instance.MakeRequest("notifications.get");

            if (Facebook.Instance.Format == ResponseType.Json)
            {
				Console.WriteLine(response);
            }

            throw new NotImplementedException("Looks like that call isn't supported yet");
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

			string response = Facebook.Instance.MakeRequest("notifications.send", parameters);

            if (Facebook.Instance.Format == ResponseType.Json)
            {
				return true;
            }

            throw new NotImplementedException("Looks like that call isn't supported yet");
		}
		#endregion
    }
}
