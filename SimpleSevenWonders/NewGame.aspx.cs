using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using SimpleSevenWonders.Data;
using SimpleSevenWonders.Models;

namespace SimpleSevenWonders
{
	public partial class NewGame : System.Web.UI.Page
	{
		private int _nrOfPlayers;
		private List<string> _players = new List<string> { "William", "Ferdinand", "Frederik" };
		private const int UnitWidth = 100;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IdentityHelper.IsWondersAdmin())
			{
				Submit.Enabled = false;
				Submit.Text = "Not Authorized";
				return;
			}
			if (!int.TryParse(Request.QueryString["NoP"], out _nrOfPlayers))
			{
				_nrOfPlayers = 3;
			}

			var topPanel = new Panel();
			topPanel.Controls.Add(new Label { Text = "Player", CssClass = "PointHeaders" });
			topPanel.Controls.Add(new Label { Text = "Red Points", CssClass = "PointHeaders" });
			topPanel.Controls.Add(new Label { Text = "Coin Points", CssClass = "PointHeaders" });
			topPanel.Controls.Add(new Label { Text = "Wonder Points", CssClass = "PointHeaders" });
			topPanel.Controls.Add(new Label { Text = "Blue Points", CssClass = "PointHeaders" });
			topPanel.Controls.Add(new Label { Text = "Orange Points", CssClass = "PointHeaders" });
			topPanel.Controls.Add(new Label { Text = "Purple Points", CssClass = "PointHeaders" });
			topPanel.Controls.Add(new Label { Text = "Green Points", CssClass = "PointHeaders" });
			inputBoard.Controls.Add(topPanel);
			inputBoard.Controls.Add(new Label { Text = "</br>" });

			for (var i = 0; i < _nrOfPlayers; i++)
			{
				var players = new DropDownList { CssClass = "PointBox", ID = $"player_{i}"};

				using (var db = new ApplicationDbContext())
				{
					foreach (var dbPlayer in db.Players)
					{
						players.Items.Add(new ListItem(dbPlayer.Name, $"{dbPlayer.Id}"));
					}
				}
				var panel = new Panel();
				panel.Controls.Add(players);
				panel.Controls.Add(new TextBox { CssClass = "PointBox", Text = "0", ID = $"Red_{i}", BackColor = Color.LightCoral });
				panel.Controls.Add(new TextBox { CssClass = "PointBox", Text = "0", ID = $"Coin_{i}", BackColor = Color.LightGoldenrodYellow });
				panel.Controls.Add(new TextBox { CssClass = "PointBox", Text = "0", ID = $"Wonder_{i}", BackColor = Color.LightGoldenrodYellow });
				panel.Controls.Add(new TextBox { CssClass = "PointBox", Text = "0", ID = $"Blue_{i}", BackColor = Color.Aqua });
				panel.Controls.Add(new TextBox { CssClass = "PointBox", Text = "0", ID = $"Orange_{i}", BackColor = Color.LightSalmon });
				panel.Controls.Add(new TextBox { CssClass = "PointBox", Text = "0", ID = $"Purple_{i}", BackColor = Color.MediumPurple });
				panel.Controls.Add(new TextBox { CssClass = "PointBox", Text = "0", ID = $"Green_{i}", BackColor = Color.LightGreen });
				inputBoard.Controls.Add(panel);
			}
		}

		protected void Submit_Click(object sender, EventArgs e)
		{
			using (var db = new ApplicationDbContext())
			{
				var playersPlayerPoints = new List<PlayerPoints>();
				for (var i = 0; i < _nrOfPlayers; i++)
				{
					var playerPoints = new PlayerPoints
					{
						Player = GetPlayer(i, db),
						BluePoints = GetPoints("Blue_", i),
						CoinPoints = GetPoints("Coin_", i),
						GreenPoints = GetPoints("Green_", i),
						OrangePoints = GetPoints("Orange_", i),
						PurplePoints = GetPoints("Purple_", i),
						RedPoints = GetPoints("Red_", i),
						WonderPoints = GetPoints("Wonder_", i)

					};
					playersPlayerPoints.Add(playerPoints);
				}
				var game = new Game
				{
					PlayerPoints = playersPlayerPoints,
					RegTime = DateTime.Now
				};
				db.Games.Add(game);
				db.SaveChanges();
			}
		}

		private int GetPoints(string prefix, int i)
		{
			var pointsBox = inputBoard.FindControl(prefix + i) as TextBox;

			if (pointsBox != null) return int.Parse(pointsBox.Text);

			throw new Exception($"GetPoints: {prefix}{i}, Control not found");
		}

		private Player GetPlayer(int i, ApplicationDbContext db)
		{
			var dropDownList = inputBoard.FindControl($"player_{i}") as DropDownList;
			if (dropDownList == null)
				throw new Exception("GetPlayer: " + i + ", Control not found");
			var playerId = int.Parse(dropDownList.SelectedItem.Value);
			return db.Players.First(x => x.Id == playerId);
		}
	}

	internal class PlayerNotFoundException : Exception
	{
	}
}