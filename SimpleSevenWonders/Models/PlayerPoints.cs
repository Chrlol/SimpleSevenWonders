namespace SimpleSevenWonders.Models
{
	public class PlayerPoints
	{
		public int Id { get; set; }
		public Player Player { get; set; }
		public int RedPoints { get; set; }
		public int CoinPoints { get; set; }
		public int WonderPoints { get; set; }
		public int BluePoints { get; set; }
		public int OrangePoints { get; set; }
		public int PurplePoints { get; set; }
		public int GreenPoints { get; set; }
	}
}