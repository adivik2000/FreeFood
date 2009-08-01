using System;
using System.IO; 
using System.Reflection;
using System.Collections.Generic;

namespace FreeFood.Utils 
{
	public sealed class Singleton
	{
		public Dictionary<string, string> config = new Dictionary<string, string>();

		Singleton()
		{
		}

		public static Singleton Instance
		{
			get
			{
				return Nested.instance;
			}
		}

		class Nested
		{
			static Nested()
			{
			}

			internal static readonly Singleton instance = new Singleton();
		}

	}
	public class ConfigParser
	{
		protected string configFile;
		protected Stream configStream = null;

		public ConfigParser()
		{
			this.configFile = "config.ini";
		}

		public ConfigParser(System.Reflection.Assembly assembly, string resource)
		{
			Assembly a = Assembly.GetExecutingAssembly();
			Stream s = a.GetManifestResourceStream(resource);

			this.configStream = s;
		}

		public ConfigParser(string filename)
		{
			this.configFile = filename;
		}

		public void Parse()
		{
			StreamReader tr;
			
			if ( configStream != null)
			{
				tr = new StreamReader( this.configStream );
			} else {
				tr = new StreamReader( this.configFile );
			}
			string line;
			//Dictionary<string, string> config = new Dictionary<string, string>();
			Singleton single = Singleton.Instance;
			Dictionary<string, string> config = single.config;

			while ((line = tr.ReadLine()) != null)
			{
				// Allow for comments and empty lines.
				if (line == "" || line.StartsWith("#"))
					continue;

				string[] kvPair = line.Split('=');

				// Format must be option = value.
				if (kvPair.Length != 2)
					continue;

				// If the option already exists, it's overwritten.
				config[kvPair[0].Trim()] = kvPair[1].Trim();
			}


		}

	}
}

