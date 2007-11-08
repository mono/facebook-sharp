using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace Mono.Facebook.Platform
{
    public class Facebook
    {
        #region "Member Variables"
        private static Facebook _instance = null;
        private const string _unsecure_server_url =  "http://api.facebook.com/bestserver.php";
        private const string _secure_server_url = "https://api.facebook.com/bestserver.php";
        private const string _version = "1.0";

        private string _api_key;
        private string _secret;
        private string _app_url;
        private UserSession _session;
        private string _response_type = "JSON";
        private string _server_url = _unsecure_server_url;
		private JavaScriptSerializer _serializer = null;

        private Notifications _notifications = null;
        private FQL _fql = null;
        private Feed _feed = null;
        private FBML _fbml = null;
        private Friends _friends = null;
        private Groups _groups = null; 
        private Photos _photos = null;
        private Profile _profile = null;
        private Events _events = null;
        private Data _data = null;
        #endregion

        #region "Static Properties"
        public static Facebook Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Facebook();
                return _instance;
            }
        }
        #endregion

        #region "Properties"
        public UserSession Session
        {
            get { return _session; }
        }
		public JavaScriptSerializer Serializer
		{
			get { return _serializer; }
		}
        public string ApiKey
        {
            get { return _api_key; }
            set { _api_key = value; }
        }
        public string Secret 
        {
            get { return _secret; }
            set { _secret = value; }
        }
        public string Url 
        {
            get { return _app_url; }
            set { _app_url = value; }
        }
        public ResponseType Format
        {
            get
            {
                if (_response_type == "JSON")
                    return ResponseType.Json;
                else
                    return ResponseType.Xml;
            }
            set
            {
                if (value == ResponseType.Json)
                    _response_type = "JSON";
                else if (value == ResponseType.Xml)
                    _response_type = "XML";
                else
                    throw new UnsupportedResponseTypeException();
            }
        }
        public bool Secure
        {
            get
            {
                if (_server_url == _unsecure_server_url)
                    return false;
                else
                    return true;
            }
            set
            {
                if (value == true)
                    _server_url = _secure_server_url;
                else
                    _server_url = _unsecure_server_url;
            }
        }

        public Notifications Notifications
        {
            get
            {
                if (_notifications == null)
                    _notifications = new Notifications();
                return _notifications;
            }
        }
        public Friends Friends
        {
            get 
            {
                if (_friends == null)
                    _friends = new Friends();
                return _friends;
            }
        }
        public FQL FQL
        {
            get 
            {
                if (_fql == null)
                    _fql = new FQL();
                return _fql;
            }
        }
        public Groups Groups
        {
            get 
            {
                if (_groups == null)
                    _groups = new Groups();
                return _groups;
            }
        }
        public Feed Feed
        {
            get
            {
                if (_feed == null)
                    _feed = new Feed();
                return _feed;
            }
        }
        public FBML FBML
        {
            get
            {
                if (_fbml == null)
                    _fbml = new FBML();
                return _fbml;
            }
        }
        public Photos Photos
        {
            get
            {
                if (_photos == null)
                    _photos = new Photos();
                return _photos;
            }
        }
        public Profile Profile 
        {
            get
            {
                if (_profile == null)
                    _profile = new Profile();
                return _profile;
            }
        }
        public Events Events
        {
            get
            {
                if (_events == null)
                    _events = new Events();
                return _events;
            }
        }
        public Data Data
        {
            get
            {
                if (_data == null)
                    _data = new Data();
                return _data;
            }
        }
        #endregion

        #region "Constructors"
        private Facebook()
        {
			_serializer = new JavaScriptSerializer();
        }
        #endregion

        #region "Public Methods"
		public bool RequireAdd(Page source)
		{
			if (String.IsNullOrEmpty(this.ApiKey))
			{
				throw new InvalidFacebookObjectException("You must first set the API Key for this application before calling RequireAdd()");
			}
			string fb_uid = source.Request.Params.Get("fb_sig_user");
			string session_key = source.Request.Params.Get("fb_sig_session_key");
			if (String.IsNullOrEmpty(session_key))
			{
				source.Response.Write(this.InstallHTML());
				source.Response.Write(this.InstallFBML());
				return false;
			}
			else
			{
				this.SessionSetup(Convert.ToInt64(fb_uid), session_key);
				return true;
			}
		}
		public bool RequireLogin(Page source)
		{
			if (String.IsNullOrEmpty(this.ApiKey))
			{
				throw new InvalidFacebookObjectException("You must first set the API Key for this application before calling RequireAdd()");
			}
			string fb_uid = source.Request.Params.Get("fb_sig_user");
			string session_key = source.Request.Params.Get("fb_sig_session_key");
			if (String.IsNullOrEmpty(session_key))
			{
				source.Response.Write(this.LoginHTML());
				source.Response.Write(this.LoginFBML());
				return false;
			}
			else
			{
				this.SessionSetup(Convert.ToInt64(fb_uid), session_key);
				return true;
			}
		}
        public string MakeRequest(string method)
        {
            return MakeRequest(method, new Dictionary<string, string>());
        }
        public string MakeRequest(string method, Dictionary<string, string> parameters)
        {
            return MakeRequest(method, parameters, string.Empty);
        }
        public string MakeRequest(string method, Dictionary<string, string> parameters, string callback)
        {
            parameters["method"] = method;
            parameters["api_key"] = _api_key;
            parameters["session_key"] = _session.SessionKey;
            parameters["v"] = _version;
            parameters["format"] = _response_type;
            parameters["sig"] = BuildSig(parameters);

            string encoded_parameters = PrepareQueryString(parameters);
            byte[] post_bytes = Encoding.ASCII.GetBytes(encoded_parameters);

            WebRequest req = WebRequest.Create(_server_url);
            WebResponse resp = null;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = post_bytes.Length;
            
            Stream post_stream = req.GetRequestStream();
            post_stream.Write(post_bytes, 0, post_bytes.Length);
            post_stream.Close();

            resp = req.GetResponse();

            if (resp == null)
                throw new InvalidAPIResponseException(String.Format("Calling {0} returned no data!"));
            
            StreamReader reader = new StreamReader(resp.GetResponseStream());

            return reader.ReadToEnd().Trim();
        }
        #endregion

        #region "Internal Methods"
        internal string BuildSig(Dictionary<string, string> parameters)
        {
            StringBuilder sig = new StringBuilder();
            StringBuilder hash = new StringBuilder();
            List<string> keys = new List<string>();

            //  Build a list of the keys so we can sort those for the sig generation
            foreach (string key in parameters.Keys)
                keys.Add(key);
            keys.Sort();

            foreach (string key in keys)
                sig.Append(String.Format("{0}={1}", key, parameters[key]));
            sig.Append(_secret);

            byte[] md5_bytes = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(sig.ToString()));

            foreach (byte bit in md5_bytes)
                hash.Append(bit.ToString("x2"));

            sig = null;
            keys = null;

            return hash.ToString();
        }
        internal string PrepareQueryString(Dictionary<string, string> dict)
        {
            StringBuilder builtString = new StringBuilder();
            int count = 0;

            foreach (string key in dict.Keys)
            {
                builtString.Append(String.Format("{0}={1}", key, dict[key]));
                if (count < (dict.Count - 1))
                    builtString.Append("&");
                count++;
            }

            return builtString.ToString();
        }
        internal void SessionSetup(long uid, string session_key)
        {
            _session = new UserSession(uid, session_key);
        }
		internal string InstallFBML()
		{
			return String.Format("<fb:redirect url=\"http://www.facebook.com/install.php?api_key={0}\"/>", this.ApiKey);
		}
		internal string InstallHTML()
		{
			return String.Format("<html><head></head><body><script> window.parent.location = 'http://www.facebook.com/install.php?api_key={0}'; </script></body></html>", this.ApiKey);
		}
		internal string LoginFBML()
		{
			return String.Format("<fb:redirect url=\"http://www.facebook.com/login.php?api_key={0}&v=1.0\"/>", this.ApiKey);
		}
		internal string LoginHTML()
		{
			return String.Format("<html><head></head><body><script> window.parent.location = 'http://www.facebook.com/login.php?api_key={0}&v=1.0'; </script></body></html>", this.ApiKey);
		}
        #endregion
    }
}
