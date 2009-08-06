using System;
using Gtk;
using Glade;
namespace FreeFood.Client.WindowType
{
	public class BarWindow : AppWindow
	{
		[Glade.Widget]
			public Window window1;

		[Glade.Widget]
			public VBox vbBar;

		[Glade.Widget]
			public EventBox eveBar;

		[Glade.Widget]
			public EventBox eveParent;

		[Glade.Widget]
			TreeView tvBar;	
		
		public BarWindow () : base()
		{
			this.Title = "Bar";

			Glade.XML gxml = new Glade.XML ("ui/bar.glade", "window1", null);
			gxml.Autoconnect (this);

			CellRendererToggle crt = new CellRendererToggle();
			crt.Activatable = true;
			crt.Toggled += crt_toggled;


			Gtk.ListStore foodListStore = new Gtk.ListStore (typeof(int), typeof (string), typeof (int), typeof(bool));
			tvBar.AppendColumn ("card", new Gtk.CellRendererText (), "text", 0);
			tvBar.AppendColumn ("product", new Gtk.CellRendererText (), "text", 1);
			tvBar.AppendColumn ("quant", new Gtk.CellRendererText (), "text", 2);
			tvBar.AppendColumn ("done", crt, "active", 3);

			tvBar.Model = foodListStore;

			foodListStore.AppendValues (1, "Cerveja Skoll lata", 1, 1);
			foodListStore.AppendValues (1, "Submarino", 2, 1);

		}

		void crt_toggled(object o, ToggledArgs args) {
			TreeIter iter;
			Console.WriteLine("Toggled");
			Gtk.ListStore store = (Gtk.ListStore) tvBar.Model;

			if (store.GetIter (out iter, new TreePath(args.Path))) {
				bool old = (bool) store.GetValue(iter, 3);
				store.SetValue(iter, 3, !old);
			}
		}

	}
}
