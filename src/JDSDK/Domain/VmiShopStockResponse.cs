using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VmiShopStockResponse:JdObject{
      [JsonProperty("vmiShopStocks")]
public 				List<string>

             vmiShopStocks
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
	}
}
