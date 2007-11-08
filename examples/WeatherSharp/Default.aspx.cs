using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mono.Facebook.Platform;

namespace WeatherSharp
{	
	public class Default : Page
	{
		private const string fb_api_key = "faa2d448ae1e771a2beb4773f00c70c7";
		private const string fb_secret = "21f9bb4a5c9cbf5968de02933f30ff3a";
		
		protected DataGrid WeatherDataGrid;
		
		protected long fb_uid;
		protected string fb_session_key;
		protected string zipcode;
		protected string city;
		
		private WeatherForecast forecaster;
		private WeatherForecasts weather;
		
		
		public virtual void Page_Load(object sender, EventArgs e)
		{
            Facebook.Instance.ApiKey = fb_api_key;
            Facebook.Instance.Secret = fb_secret;
			if (!Facebook.Instance.RequireAdd(this))
				return;

			fb_uid = Convert.ToInt64(Request.Params.Get("fb_sig_user"));
			fb_session_key = Request.Params.Get("fb_sig_session_key");
			forecaster = new WeatherForecast();

			///Console.WriteLine(Users.GetInfo());
			User user = Users.GetInfo(new string[] {"name", "current_location", "affiliations"});

			//Console.WriteLine(FQL.Query(String.Format("SELECT name, affiliations FROM user WHERE uid = {0}", fb_uid)));
			
			Profile.SetFbml(String.Format("<strong>Last updated the profile at {0}</strong>", DateTime.Now));
			Notifications.Get();

			LoadWeatherData(user);

			// XXX: Silly load testing stuff
			/*
			for (int i = 0; i < 50; ++i)
			{
				DateTime start = DateTime.Now;
				Users.GetInfo();
				TimeSpan diff = (DateTime.Now - start);
				Console.WriteLine("Time taken: {0}", diff.Milliseconds);
			}
			*/
		}	
		
		
		private void LoadWeatherData(User user)
		{
			zipcode = user.current_location.zip;
			city = user.current_location.city;
			
			if ( (!String.IsNullOrEmpty(zipcode)) && (zipcode != "0") )
			{
				weather = forecaster.GetWeatherByZipCode(zipcode);
			}
			else if (!String.IsNullOrEmpty(city))
			{
				weather = forecaster.GetWeatherByPlaceName(city);
			}
			else
			{
				weather = null;
				Console.WriteLine("Couldn't find any location information! D'oh!");
			}
			
			if (weather != null)
			{
				WeatherDataGrid.DataSource = this.GenerateWeatherDataSource(weather);
				WeatherDataGrid.DataBind();
			}	
		}
		
	    private ICollection GenerateWeatherDataSource(WeatherForecasts weather)
	    {    	
	        DataTable dt = new DataTable();
	        DataRow dr;

	        dt.Columns.Add(new DataColumn(" ", typeof(string))); // Used for image
	        dt.Columns.Add(new DataColumn("Day", typeof(string)));
	        dt.Columns.Add(new DataColumn("Low", typeof(string)));
	        dt.Columns.Add(new DataColumn("High", typeof(string)));
	    	
	    	WeatherData[] details = weather.Details;
	    	
	    	foreach (WeatherData data in details)
	    	{
	    		if (data.Day != null)
	    		{
	    			dr = dt.NewRow();
	    			
	    			dr[0] = String.Format("<img src=\"{0}\"/>", data.WeatherImage);
	    			dr[1] = data.Day;
	    			dr[2] = data.MinTemperatureF;
	    			dr[3] = data.MaxTemperatureF;
	    			
	    			dt.Rows.Add(dr);
	    		}
	    	}

	        return new DataView(dt);
	    }
    }
}
