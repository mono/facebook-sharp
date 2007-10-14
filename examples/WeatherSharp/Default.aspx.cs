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
			fb_uid = Convert.ToInt64(Request.Params.Get("fb_sig_user"));
			fb_session_key = Request.Params.Get("fb_sig_session_key");
			forecaster = new WeatherForecast();

            Facebook.Instance.ApiKey = fb_api_key;
            Facebook.Instance.Secret = fb_secret;
            Facebook.Instance.SessionSetup(fb_uid, fb_session_key);
			User user = Users.GetInfo(new string[] {"name", "current_location"});

			LoadWeatherData(user);
		}	
		
		
		private void LoadWeatherData(User user)
		{
			zipcode = user.current_location.zip;
			city = user.current_location.city;
			
			if (zipcode != "0")
			{
				weather = forecaster.GetWeatherByZipCode(zipcode);
			}
			else if (city != string.Empty)
			{
				weather = forecaster.GetWeatherByPlaceName(city);
			}
			else
			{
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
