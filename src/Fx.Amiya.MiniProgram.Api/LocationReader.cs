using Fx.Common.Utils;
using Fx.Infrastructure.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api
{
	public class LocationReader
	{

		public static async Task<string> GetCityAsync(decimal latitude, decimal longitude)
		{
			try
			{
                string json = await RequestCityAsync(latitude, longitude);
				if (!json.Contains("addressComponent"))
				{
					json=await RequestCityAsync(latitude, longitude);
				}	
				var res = JsonConvert.DeserializeObject<dynamic>(json);
				return res.result.addressComponent.city.ToString();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		private static async Task<string> RequestCityAsync(decimal latitude, decimal longitude)
		{
			string url = $"http://api.map.baidu.com/geocoder?location={latitude},{longitude}&output=json";
			return await HttpUtil.HTTPJsonGetAsync(url);
		}
    }

	
}
