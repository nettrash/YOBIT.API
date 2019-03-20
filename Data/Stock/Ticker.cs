using Newtonsoft.Json;

namespace YOBIT.API.Data.Stock
{
	[JsonObject]
	public class Ticker
	{
		#region Public properties



		[JsonProperty("bio_rur")]
		public MarketTicker BIORUR { get; set; }

		[JsonProperty("bio_btc")]
		public MarketTicker BIOBTC { get; set; }



		#endregion
	}
}
