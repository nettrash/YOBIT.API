using System.Collections.Generic;
using System.Threading.Tasks;

namespace YOBIT.API
{
	public class Trade : Core
	{
		#region Public constructors



		public Trade()
			: base()
		{

		}

		public Trade(string sKey, string sSecret)
			: base(sKey, sSecret)
		{

		}



		#endregion
		#region Protected methods



		public async Task<Data.Market.Response<Data.Market.Order>> CreateOrderAsync(int nNonce, string sType, string sPair, decimal nRate, decimal nAmount, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			Dictionary<string, string> prms = new Dictionary<string, string>();
			prms.Add("method", Properties.Settings.Default.TradeMethod);
			prms.Add("pair", sPair);
			prms.Add("type", sType);
			prms.Add("rate", nRate.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture));
			prms.Add("amount", nAmount.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture));
			prms.Add("nonce", nNonce.ToString());
			string sResponse = await SendPOSTRequestAsync(Properties.Settings.Default.TradeAPIUrl, true, prms, cancellationToken);
			return Newtonsoft.Json.JsonConvert.DeserializeObject<Data.Market.Response<Data.Market.Order>>(sResponse);
		}



		#endregion
		#region Public methods



		public async Task<Data.Market.Response<Data.Market.Order>> BuyAsync(int nNonce, string sPair, decimal nRate, decimal nAmount, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return await CreateOrderAsync(nNonce, "buy", sPair, nRate, nAmount, cancellationToken);
		}

		public async Task<Data.Market.Response<Data.Market.Order>> SellAsync(int nNonce, string sPair, decimal nRate, decimal nAmount, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return await CreateOrderAsync(nNonce, "sell", sPair, nRate, nAmount, cancellationToken);
		}



		#endregion
	}
}
