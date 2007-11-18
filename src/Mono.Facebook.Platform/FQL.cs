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

			return Facebook.Instance.MakeRequest<T>("fql.query", parameters);
		}
		#endregion
    }
}

