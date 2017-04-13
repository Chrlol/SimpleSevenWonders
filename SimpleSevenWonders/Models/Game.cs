using System.Collections.Generic;

namespace SimpleSevenWonders.Models
{
	public class Game
	{
		public int Id { get; set; }
		public List<PlayerPoints> PlayerPoints { get; set; }
	}
}