using Newtonsoft.Json;

namespace YOBIT.API.Data.Market
{
	[JsonObject]
	public class Order
	{
		#region Public properties



		[JsonProperty("received")]
		public decimal Received { get; set; }

		[JsonProperty("remains")]
		public decimal Remains { get; set; }

		[JsonProperty("order_id")]
		public ulong Id { get; set; }



		#endregion
	}
}
