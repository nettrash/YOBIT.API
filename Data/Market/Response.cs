using Newtonsoft.Json;

namespace YOBIT.API.Data.Market
{
	[JsonObject]
	public class Response<T>
	{
		#region Public properties



		[JsonProperty("success")]
		public int Success { get; set; }

		[JsonProperty("return")]
		public T Result { get; set; }

		[JsonProperty("error")]
		public string Error { get; set; }
		


		#endregion
	}
}
