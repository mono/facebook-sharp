using System;
using System.Collections.Generic;

namespace Mono.Facebook.Platform
{
    public class Friends
    {
		#region "Public Static Methods (Facebook)"
		public static bool AreFriends(Int64 uid1, Int64 uid2)
		{
			List<Dictionary<string, string>> areFriends = Friends.AreFriends(new Int64[] { uid1 }, new Int64[] { uid2 });
			if (areFriends.Count > 0)
			{
				return Convert.ToBoolean(areFriends[0]["are_friends"]);
			}
			return false;
		}
		public static List<Dictionary<string, string>> AreFriends(List<Int64> uids1, List<Int64> uids2)
		{
			return Friends.AreFriends(uids1.ToArray(), uids2.ToArray());
		}
		public static List<Dictionary<string, string>> AreFriends(Int64[] uids1, Int64[] uids2)
		{
            Dictionary<string, string> parameters = new Dictionary<string, string>();
			string[] uids1_str = Array.ConvertAll<Int64, String>(uids1, Utility.LongToString);
			string[] uids2_str = Array.ConvertAll<Int64, String>(uids2, Utility.LongToString);
			parameters.Add("uids1", String.Join(",", uids1_str));
			parameters.Add("uids2", String.Join(",", uids2_str));

			/*
			 * NOTE: This will explode in a lovely manner when used in conjunction with test accounts, since instead of 
			 * a boolean true/false, Facebook returns a JSON null
			 * see bug: http://bugs.developers.facebook.com/show_bug.cgi?id=807
			 */
			return Facebook.Instance.MakeRequest<List<Dictionary<string, string>>>("friends.areFriends", parameters);
		}

		public static List<Int64> Get()
		{
			return Facebook.Instance.MakeRequest<List<Int64>>("friends.get");
		}

		public static List<Int64> GetAppUsers()
		{
			return Facebook.Instance.MakeRequest<List<Int64>>("friends.getAppUsers");
		}
		#endregion
    }
}
