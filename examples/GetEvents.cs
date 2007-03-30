using System;
using System.Collections.Generic;
using Mono.Facebook;

namespace Mono.Facebook.Test
{
	class GetEvents
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
			session.GetSession ();

			Me me = session.GetLoggedInUser ();
			foreach (Event e in me.Events) {
				Console.WriteLine ("Event Name: {0}", e.Name);
				Console.WriteLine ("Attending: {0}", e.MemberList.Attending.Length);
			}
		}
	}
}
