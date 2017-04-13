using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;

namespace SimpleSevenWonders
{
	public partial class NewGame : System.Web.UI.Page
	{
		private int _nrOfPlayers;
		private List<string> _players = new List<string>{"William", "Ferdinand", "Frederik"};
		private const int UnitWidth = 100;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!int.TryParse(Request.QueryString["NoP"], out _nrOfPlayers))
			{
				TopText.Text = "Invalid Querystring";
			}

			TopText.Text = $"nr of players:{_nrOfPlayers}";
			var label = new Label();
			var topPanel = new Panel();
			topPanel.Controls.Add(new Label { Text = "Player", Width = UnitWidth});
			topPanel.Controls.Add(new Label { Text = "Red Points", Width = UnitWidth });
			topPanel.Controls.Add(new Label { Text = "Coin Points", Width = UnitWidth });
			topPanel.Controls.Add(new Label { Text = "Wonder Points", Width = UnitWidth });
			topPanel.Controls.Add(new Label { Text = "Blue Points", Width = UnitWidth });
			topPanel.Controls.Add(new Label { Text = "Orange Points", Width = UnitWidth });
			topPanel.Controls.Add(new Label { Text = "Purple Points", Width = UnitWidth });
			topPanel.Controls.Add(new Label { Text = "Green Points", Width = UnitWidth });
			inputBoard.Controls.Add(topPanel);

			for (var i = 0; i < _nrOfPlayers; i++)
			{
				var players = new DropDownList {Width = UnitWidth};
				foreach (var player in _players)
				{
					players.Items.Add(player);
				}
				var panel = new Panel();
				panel.Controls.Add(players);
				panel.Controls.Add(new TextBox { Width = UnitWidth, ID = "Red_" + i, BackColor = Color.LightCoral});
				panel.Controls.Add(new TextBox { Width = UnitWidth, ID = "Coin_" + i, BackColor = Color.LightGoldenrodYellow });
				panel.Controls.Add(new TextBox { Width = UnitWidth, ID = "Wonder_" + i, BackColor = Color.LightGoldenrodYellow });
				panel.Controls.Add(new TextBox { Width = UnitWidth, ID = "Blue_" + i, BackColor = Color.Aqua });
				panel.Controls.Add(new TextBox { Width = UnitWidth, ID = "Orange_" + i, BackColor = Color.LightSalmon });
				panel.Controls.Add(new TextBox { Width = UnitWidth, ID = "Purple_" + i, BackColor = Color.MediumPurple });
				panel.Controls.Add(new TextBox { Width = UnitWidth, ID = "Green_" + i, BackColor = Color.LightGreen });
				inputBoard.Controls.Add(panel);
			}
		}

		protected void Submit_Click(object sender, EventArgs e)
		{
			TopText.Text = ((TextBox)inputBoard.FindControl("Wonder_2")).Text;
		}
	}
}