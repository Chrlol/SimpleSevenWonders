using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using SimpleSevenWonders.Models;
using MoreLinq;

namespace SimpleSevenWonders
{
	public partial class Default : Page
	{
		public List<ViewGame> ViewGames;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IdentityHelper.IsWondersAdmin())
			{
				CreatePlayer.Enabled = false;
				CreatePlayer.Text = "Not Authorized";
			}
			ViewGames = new List<ViewGame>();
			using (var db = new ApplicationDbContext())
			{
				foreach (var dbGame in db.Games.ToList())
				{
					ViewGames.Add(new ViewGame
					{
						Id = dbGame.Id,
						Winner = dbGame.PlayerPoints.ToList().MaxBy(x => x.Total).Player,
						WinnerName = dbGame.PlayerPoints.ToList().MaxBy(x => x.Total).Player.Name,
						RegTime = dbGame.RegTime
					});
				}
			}
			Games.DataSource = ViewGames;
			Games.DataBind();
		}

		protected void GoToGameCreationPage_Click(object sender, EventArgs e)
		{
			Response.Redirect("NewGame.aspx?NoP=" + NrOfPlayers.SelectedItem.Value);
		}

		protected void CreatePlayer_Click(object sender, EventArgs e)
		{
			if (!IdentityHelper.IsWondersAdmin())
			{
				Response.Write("<p style=\"color: red;\" > Not Authorized</p>");
				return;
			}
			var player = new Player { Name = PlayerName.Text };

			using (var db = new ApplicationDbContext())
			{
				db.Players.Add(player);
				db.SaveChanges();
			}
			Response.Redirect("Default.aspx");
		}
	}
}