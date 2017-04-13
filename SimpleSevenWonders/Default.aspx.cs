using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleSevenWonders.Data;
using SimpleSevenWonders.Models;

namespace SimpleSevenWonders
{
	public partial class Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IdentityHelper.IsWondersAdmin())
			{
				CreatePlayer.Enabled = false;
				CreatePlayer.Text = "Not Authorized";
			}
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