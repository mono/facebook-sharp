//
// Mono.Facebook.User.cs:
//
// Authors:
//	Thomas Van Machelen (thomas.vanmachelen@gmail.com)
//	George Talusan (george@convolve.ca)
//
// (C) Copyright 2007 Novell, Inc. (http://www.novell.com)
//

// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Xml.Serialization;

namespace Mono.Facebook
{
	public partial class User
	{
		public static readonly string[] FIELDS = { "about_me", "activities", "affiliations", "birthday", "books", 
			"current_location", "education_history", "first_name", "hometown_location", "interests", "last_name", 
			"movies", "music", "name", "notes_count", "pic", "pic_big", "pic_small", "political", "profile_update_time", 
			"quotes", "relationship_status", "religion", "sex", "significant_other_id", 
			"status", "timezone", "tv", "uid", "wall_count" };

		[XmlElement ("about_me")]
		public string AboutMe;

		[XmlElement ("activities")]
		public string Activities;

		[XmlElement ("birthday")]
		public string Birthday;

		[XmlElement ("books")]
		public string Books;

		[XmlElement ("current_location")]
		public Location CurrentLocation;

		[XmlElement ("first_name")]
		public string FirstName;

		[XmlElement ("hometown_location")]
		public Location HomeTown;

		[XmlElement ("interests")]
		public string Interests;

		[XmlElement ("last_name")]
		public string LastName;

		[XmlElement ("movies")]
		public string Movies;

		[XmlElement ("music")]
		public string Music;

		[XmlElement ("name")]
		public string Name;

		[XmlElement ("notes_count")]
		public System.Nullable<int> NotesCount;

		[XmlElement ("notes_countSpecified")]
		public bool NotesCountSpecified;

		[XmlElement ("pic")]
		public string pic;

		public Uri Picture
		{
			get
			{
				if (pic == string.Empty)
					return null;

				return new Uri (pic);
			}
		}

		[XmlElement ("pic_big")]
		public string pic_big;

		public Uri PictureBig
		{
			get 
			{
				if (pic_big == string.Empty)
					return null;

				return new Uri (pic_big);
			}
		}

		[XmlElement ("pic_small")]
		public string pic_small;

		public Uri PictureSmall
		{
			get 
			{
				if (pic_small == string.Empty)
					return null;

				return new Uri (pic_small);
			}
		}

		[XmlElement ("political")]
		public string Political;

		[XmlElement ("profile_update_time")]
		public System.Nullable<int> ProfileUpdateTime;

		[XmlElement ("profile_update_timeSpecified")]
		public bool ProfileUpdateTimeSpecified;

		[XmlElement ("quotes")]
		public string Quotes;

		[XmlElement ("relationship_status")]
		public string RelationShipStatus;

		[XmlElement ("religion")]
		public string Religion;

		[XmlElement ("sex")]
		public string Sex;

		[XmlElement ("significant_other_id")]
		public System.Nullable<int> SignificantOtherId;

		[XmlElement ("significant_other_idSpecified")]
		public bool SignificantOtherIdSpecified;

		[XmlElement ("timezone")]
		public System.Nullable<int> Timezone;

		[XmlElement ("timezoneSpecified")]
		public bool TimezonSpecified;

		[XmlElement ("tv")]
		public string TV;

		[XmlElement ("uid")]
		public int UId;

		[XmlElement ("uidSpecified")]
		public bool UIdSpecified;

		[XmlElement ("wall_count")]
		public System.Nullable<int> WallCount;

		[XmlElement ("wall_countSpecified")]
		public bool WallCountSpecified;
	}
}
