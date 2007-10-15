using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Mono.Facebook.Platform
{
    public class User
    {
        /*
         * Because System.Web.Script.Serialization sucks, and doesn't allow for specifying 
         * [JsonElement()] style attributes, forgive the terrible style of using public member
         * variables, vomit.
         */
        #region "Member Variables"
		public string uid;
        public string name;
        public string about_me;
        public string activities;
		public DateTime birthday;
        public string books;
        public string interests;
        public bool is_app_user;
        public string first_name;
        public string last_name;
        public Nullable<int> notes_count;
		public Location hometown_location;
		public Location current_location;
		public List<Affiliation> affiliations;
        public string pic;
        public string pic_big;
        public string pic_small;
        public string pic_square;
        public string quotes;
        public string religion;
        public string sex;
        public string significant_other_id;
        public Nullable<int> timezone;
        public string tv;
        public Nullable<int> wall_count;
        public bool has_added_app;
        #endregion

        #region "Constructors"
        public User()
        {
        }
        #endregion

        #region "Public Methods"
        public override string ToString()
        {
            return String.Format("UID: {0}, Name: {1}", Convert.ToInt64(uid), name);
        }
        #endregion
    }
}
