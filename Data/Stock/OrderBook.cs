using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOBIT.API.Data.Stock
{
	[JsonObject]
	public class OrderBook
	{
		#region Public properties



		[JsonProperty("bio_rur")]
		public MarketOrderBook BIORUR { get; set; }

		[JsonProperty("bio_btc")]
		public MarketOrderBook BIOBTC { get; set; }



		#endregion
	}
}