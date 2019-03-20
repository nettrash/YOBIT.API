using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOBIT.API
{
	public class Stock : Core
	{
		#region Private properties
		


		private static NLog.Logger _logger => NLog.LogManager.GetCurrentClassLogger(); 



		#endregion
		#region Public properties



		public async Task<Data.Stock.OrderBook> GetOrderBookAsync(string sMarket, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			string sResponse = await SendRequestAsync($"{Properties.Settings.Default.PublicAPIUrl}{Properties.Settings.Default.GetOrderBookMethod}{sMarket}", false, cancellationToken);
			return Newtonsoft.Json.JsonConvert.DeserializeObject<Data.Stock.OrderBook>(sResponse);
		}

		public async Task<Data.Stock.Ticker> GetTickerAsync(string sMarket, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			string sResponse = await SendRequestAsync($"{Properties.Settings.Default.PublicAPIUrl}{Properties.Settings.Default.GetTickerMethod}{sMarket}", false, cancellationToken);
			_logger.Trace(sResponse);
			return Newtonsoft.Json.JsonConvert.DeserializeObject<Data.Stock.Ticker>(sResponse);
		}



		#endregion
		#region Public constructors



		public Stock()
			: base()
		{

		}

		public Stock(string sKey, string sSecret)
			: base(sKey, sSecret)
		{

		}



		#endregion
	}
}
