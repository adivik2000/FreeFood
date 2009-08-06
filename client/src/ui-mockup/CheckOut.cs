using System;
using Gtk;
using Glade;
namespace FreeFood.Client.WindowType
{
	public class CheckOutWindow : AppWindow
	{


		[Glade.Widget]
			public Window window1;

		[Glade.Widget]
			public VBox vbCheckOut;

		[Glade.Widget]
			VBox vbCreditCard;

		[Glade.Widget]
			public EventBox eveCheckOut;

		[Glade.Widget]
			Button butFind;

		[Glade.Widget]
			TreeView tvCheckOut;	

		[Glade.Widget]
			ComboBox cbPaymentType;	

		[Glade.Widget]
			public EventBox eveParent;


		public CheckOutWindow () : base()
		{
			this.Title = "Check Out";

			Glade.XML gxml = new Glade.XML ("ui/checkout.glade", "window1", null);
			gxml.Autoconnect (this);
			butFind.Clicked += OnButFindPressButtonEvent;
			cbPaymentType.Changed += OnCbPaymentTypechanged;	

			Gtk.ListStore foodListStore = new Gtk.ListStore (typeof (string), typeof (int), typeof(string), typeof(string));
			tvCheckOut.AppendColumn ("produto", new Gtk.CellRendererText (), "text", 0);
			tvCheckOut.AppendColumn ("quantidade", new Gtk.CellRendererText (), "text", 1);
			tvCheckOut.AppendColumn ("preço u", new Gtk.CellRendererText (), "text", 2);
			tvCheckOut.AppendColumn ("preço t", new Gtk.CellRendererText (), "text", 3);

			tvCheckOut.Model = foodListStore;
		}

		private void OnCbPaymentTypechanged(object sender, EventArgs e){
			int sel = cbPaymentType.Active;
			//myLabel.Text = “Item : “+(++sel);
			Console.WriteLine(sel);
			if( sel.Equals(2) )
			{
				vbCreditCard.Visible = true;
			}
		} 

		public void OnButFindPressButtonEvent( object o, EventArgs e)
		{
			Gtk.ListStore foodListStore = (Gtk.ListStore) tvCheckOut.Model;
			foodListStore.AppendValues ("Cerveja Skoll lata", 1, "3,50", "3,50");
			foodListStore.AppendValues ("Batata Suiça - Charque - Grande", 1, "33,50", "33,50");
			foodListStore.AppendValues ("Submarino", 2, "8,50", "17,00");


			Console.WriteLine("CheckOut");	
			eveCheckOut.Visible = true;
		}
	}
}
