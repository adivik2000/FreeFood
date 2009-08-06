using System;
using Gtk;
using Glade;
using FreeFood.Client.WindowType;

public class GladeApp
{
	[Glade.Widget]
	Window winMain;

	[Glade.Widget]
	ToolButton tbtCard;	

	[Glade.Widget]
	Label lblMain;

	[Glade.Widget]
	ToolButton tbtComanda;	

	[Glade.Widget]
	ToolButton tbtCheckout; 

	[Glade.Widget]
	ToolButton tbtBar; 

	[Glade.Widget]
	ToolButton tbtKitchen; 

	[Glade.Widget]
	TreeView tvMain;	
	
	[Glade.Widget]
	EventBox eveMain;	

	protected Widget eveChild;

	public static void Main (string[] args)
	{
		new GladeApp (args);
	}

	public GladeApp (string[] args) 
	{
		Application.Init();

		//Glade.XML gxml = new Glade.XML (null, "ui/app.glade", "winMain", null);
		Glade.XML gxml = new Glade.XML ("ui/app.glade", "winMain", null);
		gxml.Autoconnect (this);
		winMain.Resize(800, 600);
		winMain.ShowAll();
		winMain.DeleteEvent += OnDeleteEvent;
	
		this.eveChild = tvMain;

		tbtCard.Clicked += OnTbtCardPressButtonEvent;
		tbtComanda.Clicked += OnTbtComandaPressButtonEvent;
		tbtCheckout.Clicked += OnTbtCheckoutPressButtonEvent; 
		tbtBar.Clicked += OnTbtBarPressButtonEvent; 
		tbtKitchen.Clicked += OnTbtKitchenPressButtonEvent; 
		Application.Run();
	}
	
	protected void ChangeEveChild(Widget widget)
	{
		eveMain.Remove(this.eveChild);
		this.eveChild = widget;
		this.eveChild.Reparent(eveMain);		
	} 
	
	public void ChangeMainLabel(string text)
	{
		this.lblMain.Text = "<big><b>" + text + "</b></big>";
		this.lblMain.UseMarkup = true;
	}

	public void OnTbtCardPressButtonEvent( object o, EventArgs e)
	{
		Console.WriteLine("TbtCard");	
		CardWindow cw = new CardWindow();
		this.ChangeMainLabel(cw.Title);
		this.ChangeEveChild(cw.hbCard);
	}

	public void OnTbtComandaPressButtonEvent( object o, EventArgs e)
	{
		Console.WriteLine("TbtComanda");	
		ComandaWindow cw = new ComandaWindow();
		this.ChangeMainLabel(cw.Title);
		this.ChangeEveChild(cw.vbComanda);
	}
	
	public void OnTbtCheckoutPressButtonEvent( object o, EventArgs e)
	{
		Console.WriteLine("TbtCheckout");	
		CheckOutWindow cw = new CheckOutWindow();
		this.ChangeMainLabel(cw.Title);
		this.ChangeEveChild(cw.vbCheckOut);
	}

	public void OnTbtBarPressButtonEvent( object o, EventArgs e)
	{
		Console.WriteLine("TbtBar");	
		BarWindow cw = new BarWindow();
		this.ChangeMainLabel(cw.Title);
		this.ChangeEveChild(cw.vbBar);
	}

	public void OnTbtKitchenPressButtonEvent( object o, EventArgs e)
	{
		Console.WriteLine("TbtKitchen");	
		KitchenWindow cw = new KitchenWindow();
		this.ChangeMainLabel(cw.Title);
		this.ChangeEveChild(cw.vbKitchen);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
