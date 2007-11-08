using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Mono.Facebook.Platform
{
    public class FQL
    {
		#region "Public Static Methods (Facebook)"
		public static object Query(string query)
		{
			return Query<string>(query);
		}
		public static T Query<T>(string query)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters["query"] = query;
			string response = Facebook.Instance.MakeRequest("fql.query", parameters);
            
            if (Facebook.Instance.Format == ResponseType.Json)
            {
				if (typeof(T) == typeof(string))
					return (T)Activator.CreateInstance(typeof(T), response.ToCharArray());
				return Facebook.Instance.Serializer.Deserialize<T>(response);
            }

            throw new NotImplementedException("Looks like that call isn't supported yet");
		}
		#endregion
    }
}

