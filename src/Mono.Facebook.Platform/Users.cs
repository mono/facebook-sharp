using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Mono.Facebook.Platform
{
    public class Users
    {
        #region "Public Static Member Variables"
        public static readonly string[] DefaultFields = new string[]{"uid", "about_me", "activities", "affiliations", "birthday", "books", "current_location", "education_history",
                    "first_name", "last_name", "has_added_app", "hometown_location", "hs_info", "interests", "is_app_user", "meeting_for", 
                    "meeting_sex", "movies", "music", "name", "notes_count", "pic", "pic_small", "pic_square", "pic_big", "political",
                    "profile_update_time", "quotes", "relationship_status", "religion", "sex", "significant_other_id", "status", "timezone",
                    "tv", "wall_count", "work_history"};
        #endregion

        #region "Public Static Methods (Facebook)"
        public static bool IsAppAdded()
        {
            string response = Facebook.Instance.MakeRequest("users.isAppAdded");
            
            if (Facebook.Instance.Format == ResponseType.Json)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Deserialize<bool>(response);
            }

            throw new NotImplementedException("Looks like that call isn't supported yet");
        }

        public static User GetInfo()
        {
			return GetInfo(DefaultFields);
        }
        public static User GetInfo(string[] fields)
        {
			List<User> users = GetInfo(new string[]{Facebook.Instance.Session.Uid.ToString()}, fields);
			if (users.Count > 0)
				return users[0];
			else
				throw new EmptyDataSetException("Facebook returned an empty user-set");
        }
        public static List<User> GetInfo(List<long> uids,  List<string> fields)
        {
            string[] _uids = Array.ConvertAll<long, string>(uids.ToArray(), delegate(long uid) { return uid.ToString(); });
            string[] _fields = fields.ToArray();

            return GetInfo(_uids, _fields);
        }
        public static List<User> GetInfo(string[] uids, string[] fields)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("uids", String.Join(",", uids));
            parameters.Add("fields", String.Join(",", fields));

            string response = Facebook.Instance.MakeRequest("users.getInfo", parameters);

            if (Facebook.Instance.Format == ResponseType.Json)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Console.WriteLine(response);
                return serializer.Deserialize<List<User>>(response);
            }

            throw new NotImplementedException("Looks like that call isn't supported yet");
        }

        public static long GetLoggedInUser()
        {
            string response = Facebook.Instance.MakeRequest("users.getLoggedInUser");

            if (Facebook.Instance.Format == ResponseType.Json)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Deserialize<Int64>(response);
            }

            throw new NotImplementedException("Looks like that call isn't supported yet");
        }
        #endregion
    }
}
