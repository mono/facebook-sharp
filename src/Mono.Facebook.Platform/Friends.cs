using System;
using System.Collections.Generic;

namespace Mono.Facebook.Platform
{
    public class Friends
    {
		#region "Public Static Methods (Facebook)"
		public static bool AreFriends(Int64 uid1, Int64 uid2)
		{
			return Friends.AreFriends(new Int64[] { uid1 }, new Int64[] { uid2 });
		}
		public static bool AreFriends(List<Int64> uids1, List<Int64> uids2)
		{
			return Friends.AreFriends(uids1.ToArray(), uids2.ToArray());
		}
		public static bool AreFriends(Int64[] uids1, Int64[] uids2)
		{
            Dictionary<string, string> parameters = new Dictionary<string, string>();
			string[] uids1_str = Array.ConvertAll<Int64, String>(uids1, Utility.LongToString);
			string[] uids2_str = Array.ConvertAll<Int64, String>(uids2, Utility.LongToString);
			parameters.Add("uids1", String.Join(",", uids1_str));
			parameters.Add("uids2", String.Join(",", uids2_str));

			string response = Facebook.Instance.MakeRequest("friends.areFriends", parameters);

			if (Facebook.Instance.Format == ResponseType.Json)
			{
				Console.WriteLine(response);
				return true;
			}
			
            throw new NotImplementedException("Looks like that call isn't supported yet");
		}
		#endregion
    }
}
