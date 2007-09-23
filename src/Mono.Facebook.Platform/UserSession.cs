using System;

namespace Mono.Facebook.Platform
{
    public class UserSession
    {
        #region "Member Variables"
        private string _session_key;
        private long _uid;
        #endregion

        #region "Properties"
        public string SessionKey
        {
            get { return _session_key; }
            set { _session_key = value; }
        }

        public long Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        #endregion

        #region "Constructors"
        public UserSession(long uid, string key)
        {
            _session_key = key;
            _uid = uid;
        }
        #endregion
    }
}
