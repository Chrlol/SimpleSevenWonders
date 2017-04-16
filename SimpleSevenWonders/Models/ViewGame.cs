using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoreLinq;

namespace SimpleSevenWonders.Models
{
	public class ViewGame 
	{
		public int Id { get; set; }
		public DateTime RegTime { get; set; }
		public Player Winner { get; set; }
		public string WinnerName { get; set; }
	}
}