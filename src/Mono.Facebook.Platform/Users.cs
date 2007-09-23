using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mono.Facebook.Platform
{
    public class Users
    {
        #region "Public Static Methods (Facebook)"
        public static bool IsAppAdded()
        {
            string response = Facebook.Instance.MakeRequest("users.isAppAdded");
            
            if (Facebook.Instance.Format == ResponseType.Json)
            {
                return JavaScriptConvert.DeserializeObject<bool>(response);
            }

            throw new NotImplementedException("Looks like that call isn't supported yet");
        }

        public static void GetInfo(string[] fields)
        {
            GetInfo(new string[]{Facebook.Instance.Session.Uid.ToString()}, fields);
        }
        public static void GetInfo(List<long> uids,  List<string> fields)
        {
            string[] _uids = Array.ConvertAll<long, string>(uids.ToArray(), delegate(long uid) { return uid.ToString(); });
            string[] _fields = fields.ToArray();

            GetInfo(_uids, _fields);
        }
        public static void GetInfo(string[] uids, string[] fields)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("uids", String.Join(",", uids));
            parameters.Add("fields", String.Join(",", fields));

            string response = Facebook.Instance.MakeRequest("users.getInfo", parameters);

            Console.WriteLine(response);
        }

        public static long GetLoggedInUser()
        {
            string response = Facebook.Instance.MakeRequest("users.getLoggedInUser");

            if (Facebook.Instance.Format == ResponseType.Json)
            {
                return JavaScriptConvert.DeserializeObject<Int64>(response);
            }

            throw new NotImplementedException("Looks like that call isn't supported yet");
        }
        #endregion
    }
}
