using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YOBIT.API
{
	public class Core
	{
		#region Private properties



		private string _key { get; set; }

		private byte[] _secretKey { get; set; }



		#endregion
		#region Public constructors



		public Core()
		{
			_key = Properties.Settings.Default.Key;
			_secretKey = Encoding.ASCII.GetBytes(Properties.Settings.Default.Secret);
		}

		public Core(string sKey, string sSecret)
		{
			_key = sKey;
			_secretKey = Encoding.ASCII.GetBytes(sSecret);
		}



		#endregion
		#region Private methods



		private byte[] _hmac(byte[] data)
		{
			System.Security.Cryptography.HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512(_secretKey);
			return hmac.ComputeHash(data);
		}



		#endregion
		#region Protected methods



		protected async Task<string> SendRequestAsync(string sUrl, bool bUseApiSign = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			HttpClient http = new HttpClient();
			HttpRequestMessage rq = new HttpRequestMessage(HttpMethod.Get, new Uri(sUrl));
			if (bUseApiSign)
			{
				rq.Headers.Add("Key", _key);
				rq.Headers.Add("Sign", String.Concat(Array.ConvertAll(_hmac(Encoding.ASCII.GetBytes(sUrl)), x => x.ToString("X2"))).ToLower());
			}
			HttpResponseMessage response = await http.SendAsync(rq, cancellationToken);
			byte[] data = await response.Content.ReadAsByteArrayAsync();
			return System.Text.Encoding.UTF8.GetString(data);
		}

		protected async Task<string> SendPOSTRequestAsync(string sUrl, bool bUseApiSign = true, Dictionary<string, string> parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			HttpClient http = new HttpClient();
			HttpRequestMessage rq = new HttpRequestMessage(HttpMethod.Post, new Uri(sUrl));
			rq.Content = new FormUrlEncodedContent(parameters);
			if (bUseApiSign)
			{
				rq.Headers.Add("Key", _key);
				string sContent = await (rq.Content as FormUrlEncodedContent).ReadAsStringAsync();
				rq.Headers.Add("Sign", String.Concat(Array.ConvertAll(_hmac(Encoding.UTF8.GetBytes(sContent)), x => x.ToString("X2"))).ToLower());
			}

			HttpResponseMessage response = await http.SendAsync(rq, cancellationToken);
			byte[] data = await response.Content.ReadAsByteArrayAsync();
			return System.Text.Encoding.UTF8.GetString(data);
		}



		#endregion
	}
}
