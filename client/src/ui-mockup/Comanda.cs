using System;
using Gtk;
using Glade;
namespace FreeFood.Client.WindowType
{
	public class ComandaWindow : AppWindow
	{

		[Glade.Widget]
			public Window window1;

		[Glade.Widget]
			public VBox vbComanda;

		[Glade.Widget]
			public EventBox eveComanda;

		[Glade.Widget]
			public EventBox eveAdd;

		[Glade.Widget]
			Button butFind;

		[Glade.Widget]
			Button butAdd;

		[Glade.Widget]
			TreeView tvComanda;	

		public ComandaWindow () : base()
		{
			this.Title = "Comanda";

			Glade.XML gxml = new Glade.XML ("ui/comanda.glade", "window1", null);
			gxml.Autoconnect (this);
			butFind.Clicked += OnButFindPressButtonEvent;
			butAdd.Clicked += OnButAddPressButtonEvent;

			Gtk.ListStore foodListStore = new Gtk.ListStore (typeof (string), typeof (int), typeof(string), typeof(string));
			tvComanda.AppendColumn ("produto", new Gtk.CellRendererText (), "text", 0);
			tvComanda.AppendColumn ("quantidade", new Gtk.CellRendererText (), "text", 1);
			tvComanda.AppendColumn ("preço u", new Gtk.CellRendererText (), "text", 2);
			tvComanda.AppendColumn ("preço t", new Gtk.CellRendererText (), "text", 3);

			tvComanda.Model = foodListStore;

		}

		public void OnButFindPressButtonEvent( object o, EventArgs e)
		{
			Gtk.ListStore foodListStore = (Gtk.ListStore) tvComanda.Model;
			foodListStore.AppendValues ("Cerveja Skoll lata", 1, "3,50", "3,50");
			foodListStore.AppendValues ("Batata Suiça - Charque - Grande", 1, "33,50", "33,50");
			foodListStore.AppendValues ("Submarino", 2, "8,50", "17,00");


			Console.WriteLine("Comanda");	
			eveComanda.Visible = true;
		}
		public void OnButAddPressButtonEvent( object o, EventArgs e)
		{
			this.eveAdd.Visible = true;
		}
	}
}
