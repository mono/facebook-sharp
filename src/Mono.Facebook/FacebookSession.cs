using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace Mono.Facebook
{
	public class FacebookSession
	{
		Util util;
		SessionInfo session_info;
		string auth_token;

		internal Util Util
		{
			get { return util; }
		}

		internal string SessionKey
		{
			get { return session_info.SessionKey; }
		}

		public FacebookSession (string api_key, string shared_secret)
		{
			util = new Util (api_key, shared_secret);
		}

		public Uri CreateToken ()
		{
			XmlDocument doc = util.GetResponse ("facebook.auth.createToken");
			auth_token = doc.InnerText;

			return new Uri (string.Format ("http://www.facebook.com/login.php?api_key={0}&v=1.0&auth_token={1}", util.ApiKey, auth_token));
		}

		public void GetSession ()
		{
			this.session_info = util.GetResponse<SessionInfo> ("facebook.auth.getSession", 
				FacebookParam.Create ("auth_token", auth_token));
			this.util.SharedSecret = session_info.Secret;
			this.auth_token = string.Empty;
		}

		public Album[] GetAlbums ()
		{
			AlbumsResponse rsp = util.GetResponse<AlbumsResponse> ("facebook.photos.getAlbums",
				FacebookParam.Create ("uid", session_info.UId),
				FacebookParam.Create ("session_key", session_info.SessionKey),
				FacebookParam.Create ("call_id", DateTime.Now.Ticks));

			foreach (Album album in rsp.Albums)
				album.Session = this;

			return rsp.Albums;
		}

		public Album CreateAlbum (string name, string description, string location)
		{
			// create parameter list
			List<FacebookParam> param_list = new List<FacebookParam> ();
			param_list.Add (FacebookParam.Create ("session_key", session_info.SessionKey));
			param_list.Add (FacebookParam.Create ("call_id", DateTime.Now.Ticks));
			param_list.Add (FacebookParam.Create ("name", name));

			if (description != null && description != string.Empty)
				param_list.Add (FacebookParam.Create ("description", description));

			if (location != null && location != string.Empty)
				param_list.Add (FacebookParam.Create ("location", location));

			// create the albums
			Album new_album = util.GetResponse<Album> ("facebook.photos.createAlbum", param_list.ToArray ());
			new_album.Session = this;

			// return
			return new_album;
		}

	}
}
