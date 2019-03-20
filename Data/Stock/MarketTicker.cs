using Newtonsoft.Json;

namespace YOBIT.API.Data.Stock
{
	[JsonObject]
	public class MarketTicker
	{
		#region Public properties



		[JsonProperty("high")]
		public decimal Hight { get; set; }

		[JsonProperty("low")]
		public decimal Low { get; set; }

		[JsonProperty("avg")]
		public decimal Avg { get; set; }

		[JsonProperty("vol")]
		public decimal Volume { get; set; }

		[JsonProperty("vol_cur")]
		public decimal VolumeCurrency { get; set; }

		[JsonProperty("last")]
		public decimal Last { get; set; }

		[JsonProperty("buy")]
		public decimal Buy { get; set; }

		[JsonProperty("sell")]
		public decimal Sell { get; set; }

		[JsonProperty("updated")]
		public ulong Updated { get; set; }



		#endregion
	}
}
