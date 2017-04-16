using System;
using System.Collections.Generic;
using MoreLinq;

namespace SimpleSevenWonders.Models
{
	public class Game
	{
		public int Id { get; set; }
		public virtual List<PlayerPoints> PlayerPoints { get; set; }
		public DateTime RegTime { get; set; }
		public Player Winner() => PlayerPoints?.MaxBy(x => x.Total).Player;
		public string WinnerName() => Winner()?.Name;
	}
}