<%@ WebService Language="C#" Class="FreeFood.FreeFoodMain" %>
 
using System;
using System.Web.Services;
 
namespace FreeFood
{
	[WebService (Namespace = "http://freefood.zedmaster.com.br/FreeFood")]
	public class FreeFoodMain : WebService
	{
		[WebMethod]
		public string GetServerVersion ()
		{
			return "0.0.1";
		}
	} 
}
