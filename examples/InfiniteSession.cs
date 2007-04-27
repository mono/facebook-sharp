using System;
using Mono.Facebook;

namespace Mono.Facebook.Test
{
	class GetAlbums
	{
		static void Main(string[] args)
		{
			// create session
			FacebookSession session = new FacebookSession("ca9511b32569d823f1d3a942b31c6c84", "61f4712317fb7a2d12581f523c01fe71");

			// create token and login with it
			Uri login = session.CreateToken();
			System.Diagnostics.Process.Start("firefox", login.AbsoluteUri);
			Console.WriteLine ("Press enter after you've logged in.");
			Console.ReadLine ();

			// get session key
			SessionInfo old_info = session.GetSession();

			// check for infinite
			if (old_info == null) {
			 	Console.WriteLine ("Not an infinite session... quitting.");
				return;
			}

			Console.WriteLine ("Infinite Session: session key {0} secret {1}", 
				old_info.SessionKey, old_info.Secret);

			Console.WriteLine ("Press enter after you've logged out.");
			Console.ReadLine ();

			SessionInfo new_info = new SessionInfo (old_info.SessionKey, old_info.UId, old_info.Secret);
			session = new FacebookSession ("ca9511b32569d823f1d3a942b31c6c84", new_info);

			foreach (Album a in session.GetAlbums ())
				Console.WriteLine (a.Name);
		}
	}
}
