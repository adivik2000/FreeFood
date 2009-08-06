using System;
using Gtk;
using Glade;
namespace FreeFood.Client.WindowType
{
	public class CardWindow : AppWindow
	{
		[Glade.Widget]
			Button tbtTakePicture;

		[Glade.Widget]
			public Window window1;

		[Glade.Widget]
			public HBox hbCard;

		[Glade.Widget]
			Image imgClientPicture;

		[Glade.Widget]
			Entry entRG;
		[Glade.Widget]
			Entry entName;
		[Glade.Widget]
			Entry entCartNumber;
		[Glade.Widget]
			Entry entFone;
		[Glade.Widget]
			Entry entEmail;
		[Glade.Widget]
			Entry entFidelity;
		[Glade.Widget]
			Entry entBirthday;

		public CardWindow () : base()
		{
			this.Title = "Card";

			Glade.XML gxml = new Glade.XML ("ui/card.glade", "window1", null);
			gxml.Autoconnect (this);
			//tbtOK.Clicked += OnPressButtonEvent;
			tbtTakePicture.Clicked += OnTakePictureEvent;
			entRG.Changed += RGChangedEvent;
			imgClientPicture.Pixbuf = new Gdk.Pixbuf ("ui/user_pic_default.svg"); 
		}


		public void OnPressButtonEvent( object o, EventArgs e)
		{
			Console.WriteLine("Button press");
			Console.WriteLine("{0} :: {1}","entRG", entRG.Text);
			Console.WriteLine("{0} :: {1}","entName", entName.Text);
			Console.WriteLine("{0} :: {1}","entCartNumber", entCartNumber.Text);
			Console.WriteLine("{0} :: {1}","entBirthday", entBirthday.Text);
			Console.WriteLine("{0} :: {1}","entFone", entFone.Text);
			Console.WriteLine("{0} :: {1}","entEmail", entEmail.Text);
			Console.WriteLine("{0} :: {1}","entFidelity", entFidelity.Text);
		}

		public void OnTakePictureEvent( object o, EventArgs e)
		{
			imgClientPicture.Pixbuf = new Gdk.Pixbuf ("ui/artista_frustrado.png"); 
		}

		public void RGChangedEvent( object o, EventArgs e)
		{
			Console.WriteLine(entRG.Text);
			if((string) entRG.Text == "2089000-2")
			{
				entName.Text = "Fernando Michelotti";
				entFone.Text = "9906-6924";
				entEmail.Text = "artista@frustrado.com.br";
				entBirthday.Text = "02/11/1977";
				imgClientPicture.Pixbuf = new Gdk.Pixbuf ("ui/artista_frustrado.png"); 
			}
		}
	}
}
