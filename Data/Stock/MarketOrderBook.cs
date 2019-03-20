using Newtonsoft.Json;

namespace YOBIT.API.Data.Stock
{
	[JsonObject]
	public class MarketOrderBook
	{
		#region Public properties



		/// <summary>
		/// Ордера на продажу
		/// </summary>
		[JsonProperty("asks")]
		public decimal[][] ASKS { get; set; }

		/// <summary>
		/// Ордера на покупку
		/// </summary>
		[JsonProperty("bids")]
		public decimal[][] BIDS { get; set; }



		#endregion
	}
}
