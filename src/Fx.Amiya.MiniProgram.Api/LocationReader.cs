using Fx.Amiya.Dto.Location;
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
				throw new Exception(ex.Message.ToString());
			}
		}
		/// <summary>
		/// 获取省市区
		/// </summary>
		/// <param name="latitude"></param>
		/// <param name="longitude"></param>
		/// <returns></returns>
		public static async Task<ProvinceCityAndDistrictDto> GetProvinceCityAndDistrictAsync(decimal latitude, decimal longitude)
		{
			try
			{
				string json = await RequestCityAsync(latitude, longitude);
				if (!json.Contains("addressComponent"))
				{
					json = await RequestCityAsync(latitude, longitude);
				}
				var res = JsonConvert.DeserializeObject<dynamic>(json);
				ProvinceCityAndDistrictDto provinceCityAndDistrictDto = new ProvinceCityAndDistrictDto();
				provinceCityAndDistrictDto.Provice = res.result.addressComponent.province.ToString();
				provinceCityAndDistrictDto.City= res.result.addressComponent.city.ToString();
				provinceCityAndDistrictDto.District= res.result.addressComponent.district.ToString();
				return provinceCityAndDistrictDto;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message.ToString());
			}
		}


		private static async Task<string> RequestCityAsync(decimal latitude, decimal longitude)
		{
			string url = $"http://api.map.baidu.com/geocoder?location={latitude},{longitude}&output=json";
			return await HttpUtil.HTTPJsonGetAsync(url);
		}
    }

	
}
