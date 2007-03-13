using System;
using System.Xml.Serialization;

namespace Mono.Facebook
{
	[XmlRoot ("auth_getSession_response", Namespace = "http://api.facebook.com/1.0/", IsNullable = false)]
	public class SessionInfo
	{
		[XmlElement ("session_key")]
		public string SessionKey;

		[XmlElement ("uid")]
		public string UId;

		[XmlElement ("secret")]
		public string Secret;
	}

	[XmlRoot ("photos_getAlbums_response", Namespace = "http://api.facebook.com/1.0/", IsNullable = false)]
	public class AlbumsResponse
	{
		[XmlElement ("album")]
		public Album[] album_array;

		[XmlIgnore ()]
		public Album[] Albums
		{
			get { return album_array ?? new Album[0]; }
		}

		[XmlAttribute ("list")]
		public bool List;
	}

	[XmlRoot ("photos_get_response", Namespace = "http://api.facebook.com/1.0/", IsNullable = false)]
	public class PhotosResponse
	{
		[XmlElement ("photo")]
		public Photo[] photo_array;

		[XmlIgnore ()]
		public Photo[] Photos
		{
			get { return photo_array ?? new Photo[0]; }
		}

		[XmlAttribute ("list")]
		public bool List;
	}

	[XmlRoot ("photos_getTags_response", Namespace = "http://api.facebook.com/1.0/", IsNullable = false)]
	public class PhotoTagsResponse
	{
		[XmlElement ("photo_tag")]
		public Tag[] tag_array;

		public Tag[] Tags
		{
			get { return tag_array ?? new Tag[0]; }
		}

		[XmlAttribute ("list")]
		public bool List;
	}
}
