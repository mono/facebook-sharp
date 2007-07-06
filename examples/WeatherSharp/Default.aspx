<%@ Page Language="C#" Inherits="WeatherSharp.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head>
	<title>Weather#</title>	
	<link rel="stylesheet" href="http://static.ak.facebook.com/css/base.css" type="text/css" />
	<link rel="stylesheet" href="http://static.ak.facebook.com/css/wallpro.css" type="text/css" />
	<link rel="stylesheet" href="http://static.ak.facebook.com/css/dialog.css" type="text/css" />
	<link rel="stylesheet" href="http://static.ak.facebook.com/css/captcha/captcha.css" type="text/css" />
	<link rel="stylesheet" href="http://static.ak.facebook.com/css/discussions.css" type="text/css" />
	<link rel="stylesheet" href="http://static.ak.facebook.com/css/dialogpro.css" type="text/css" />
	<link rel="stylesheet" href="http://static.ak.facebook.com/css/canvas.css" type="text/css" />
	<link rel="stylesheet" href="/weathersharp.css" type="text/css" />
</head>
<body>
	<br/>
	<center>
		<h2>Weather#</h2>
		<em>A Mono-based Weather Service</em>
	</center>
	<br/>
	<center>
		<div class="info_box">
			<%
				Response.Write("Using: ");
				
				if (zipcode != null) 
				{
					Response.Write("Zipcode, " + zipcode);
				}
				else if (city != null)
				{
					Response.Write("City, " + city);
				}
				else
				{
					Response.Write("Nothing! User has no viable location data stored!");
				}	
			%>
		</div>	
		<br/>
		<asp:DataGrid id="WeatherDataGrid" runat="server"
	        BorderColor="black"
	        BorderWidth="1"
	        GridLines="Both"
	        CellPadding="3"
	        CellSpacing="0"
	        Font-Size="9pt"
	        HeaderStyle-BackColor="#BFCDE4"
	        CssClass="weather_grid"
	      >
	      <AlternatingItemStyle BackColor="#EEEEEE" />
		</asp:DataGrid>
	</center>
</body>
</html>