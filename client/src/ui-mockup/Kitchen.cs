using System;
using Gtk;
using Glade;
namespace FreeFood.Client.WindowType
{
	public class KitchenWindow : AppWindow
	{
		[Glade.Widget]
			public Window window1;

		[Glade.Widget]
			public VBox vbKitchen;

		[Glade.Widget]
			public EventBox eveKitchen;

		[Glade.Widget]
			public EventBox eveParent;

		[Glade.Widget]
			TreeView tvKitchen;	
		
		public KitchenWindow () : base()
		{
			this.Title = "Kitchen";

			Glade.XML gxml = new Glade.XML ("ui/kitchen.glade", "window1", null);
			gxml.Autoconnect (this);

			CellRendererToggle crt = new CellRendererToggle();
			crt.Activatable = true;
			crt.Toggled += crt_toggled;


			Gtk.ListStore foodListStore = new Gtk.ListStore (typeof(int), typeof (string), typeof (int), typeof(bool));
			tvKitchen.AppendColumn ("card", new Gtk.CellRendererText (), "text", 0);
			tvKitchen.AppendColumn ("product", new Gtk.CellRendererText (), "text", 1);
			tvKitchen.AppendColumn ("quant", new Gtk.CellRendererText (), "text", 2);
			tvKitchen.AppendColumn ("done", crt, "active", 3);

			tvKitchen.Model = foodListStore;

			foodListStore.AppendValues (1, "Porção - Batata Frita - Grande", 1, 1);
			foodListStore.AppendValues (1, "Batata Suiça - Strogonof- Grande", 1, 1);

		}

		void crt_toggled(object o, ToggledArgs args) {
			TreeIter iter;
			Console.WriteLine("Toggled");
			Gtk.ListStore store = (Gtk.ListStore) tvKitchen.Model;

			if (store.GetIter (out iter, new TreePath(args.Path))) {
				bool old = (bool) store.GetValue(iter, 3);
				store.SetValue(iter, 3, !old);
			}
		}

	}
}
