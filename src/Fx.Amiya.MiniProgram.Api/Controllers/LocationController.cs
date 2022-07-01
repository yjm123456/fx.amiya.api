using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
		/// <summary>
		/// 根据经纬度获取城市名称
		/// </summary>
		/// <param name="latitude">纬度</param>
		/// <param name="longitude">经度</param>
		/// <returns></returns>
       [HttpGet("city")]
		public async Task<ResultData<string>> GetCity(decimal latitude, decimal longitude)
		{
			try
			{
				var res =await LocationReader.GetCityAsync(latitude, longitude);
				return ResultData<string>.Success().AddData("city",res);

			}
			catch (Exception ex)
			{
				return ResultData<string>.Fail(ex.Message);
			}
		}
    }
}