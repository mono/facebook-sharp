using System;
using System.Collections.Generic;

namespace Mono.Facebook.Platform
{
    public class Feed
    {
    	#region "Public Static Methods (Facebook)"
	public static bool PublishActionOfUser(string title)
	{
		return Feed.PublishActionOfUser(title, string.Empty);
	}
	public static bool PublishActionOfUser(string title, string body)
	{
		return Feed.PublishActionOfUser(title, body, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
	}
	public static bool PublishActionOfUser(string title, string body, string image_1, string image_1_link)
	{
		return Feed.PublishActionOfUser(title, body, image_1, image_1_link, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
	}
	public static bool PublisActionOfUser(string title, string body, string image_1, string image_1_link, string image_2, string image_2_link)
	{
		return Feed.PublishActionOfUser(title, body, image_1, image_1_link, image_2, image_2_link, string.Empty, string.Empty, string.Empty, string.Empty);
	}
	public static bool PublishActionOfUser(string title, string body, string image_1, string image_1_link, string image_2, string image_2_link, string image_3, string image_3_link)
	{
		return Feed.PublishActionOfUser(title, body, image_1, image_1_link, image_2, image_2_link, image_3, image_3_link, string.Empty, string.Empty);
	}
	public static bool PublishActionOfUser(string title, string body, string image_1, string image_1_link, string image_2, string image_2_link, string image_3, string image_3_link, string image_4, string image_4_link)
	{
		return Feed.PublishBasicFeedItem("publishActionOfUser", title, body, image_1, image_1_link, image_2, image_2_link, image_3, image_3_link, image_4, image_4_link, -1);
	}

	public static bool PublishStoryToUser(string title, string body, string image_1, string image_1_link, string image_2, string image_2_link, string image_3, string image_3_link, string image_4, string image_4_link, int priority)
	{
		return Feed.PublishBasicFeedItem("publishStoryToUser", title, body, image_1, image_1_link, image_2, image_2_link, image_3, image_3_link, image_4, image_4_link, priority);
	}

	public static bool PublishBasicFeedItem(string itemType, string title, string body, string image_1, string image_1_link, string image_2, string image_2_link, string image_3, string image_3_link, string image_4, string image_4_link, int priority)
	{
		Dictionary<string, string> parameters = new Dictionary<string, string>();
		parameters.Add("title", title);
		parameters.Add("body", body);
		parameters.Add("image_1", image_1);
		parameters.Add("image_1_link", image_1_link);
		parameters.Add("image_2", image_2);
		parameters.Add("image_2_link", image_2_link);
		parameters.Add("image_3", image_3);
		parameters.Add("image_3_link", image_3_link);
		parameters.Add("image_4", image_4);
		parameters.Add("image_4_link", image_4_link);
		if (priority > 0)
			parameters.Add("priority", priority.ToString());

		string response = Facebook.Instance.MakeRequest(String.Format("feed.{0}", itemType), paramaters);

		if (Facebook.Instance.Format == ResponseType.Json)
		{
			Console.WriteLine("Response: {0}{1}", Environment.NewLine, response);
			return true;
		}
		
		throw new NotImplementedException("Looks like that call isn't supported yet!");
	}
	#endregion	
    }
}
