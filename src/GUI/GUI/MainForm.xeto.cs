using System;
using System.Collections.Generic;
using Arkivverket.Arkade.Util;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;

namespace GUI
{	
	public class MainForm : Form
	{	
		public MainForm()
		{
			XamlReader.Load(this);
		}

		protected void HandleClickMe(object sender, EventArgs e)
		{
		    string arkadeVersion = ArkadeVersion.Current;

		    MessageBox.Show("You're running Arkade version " + arkadeVersion);
		}

		protected void HandleAbout(object sender, EventArgs e)
		{
			new AboutDialog().ShowDialog(this);
		}

		protected void HandleQuit(object sender, EventArgs e)
		{
			Application.Instance.Quit();
		}
	}
}
