using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Collections.Generic;


using FreeFood;
using FreeFood.Utils;

namespace FreeFood.Application
{
	/*
		Implement ICertificatePolicy so it will not complain about root certificates. It is a dirty hack and should be fixed soon
	*/
	public class HttpWebRequestClientCertificateTest : ICertificatePolicy {

		public bool CheckValidationResult (ServicePoint sp, X509Certificate certificate,
				WebRequest request, int error)
		{
			return true;
		}
	}

	class Application
	{
		public void LoadConfig(string initPath)
		{
                        ConfigParser parser = new ConfigParser( initPath );
                        parser.Parse();

                        Singleton single = Singleton.Instance;
                        Dictionary<string, string> config = single.config;
                }

		public void FreeFoodClient()
		{
			this.LoadConfig("etc/FreeFood.cfg");

                        Singleton single = Singleton.Instance;
                        Dictionary<string, string> config = single.config;

			X509Certificate2 certificate = new X509Certificate2 ( config["app.certificte.path"], config["app.certificate.password"]);

			ServicePointManager.CertificatePolicy = new HttpWebRequestClientCertificateTest ();

			Console.WriteLine(":p");

			FreeFoodMain ff = new FreeFoodMain();
			ff.Url = config["server.url"]; 
			ff.ClientCertificates.Add (certificate);

			Console.WriteLine(ff.GetServerVersion());	
		}


		public static void Main()
		{
			Application app = new Application();
			app.FreeFoodClient();
		}
	}
}
