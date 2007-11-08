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
		#endregion
    }
}
