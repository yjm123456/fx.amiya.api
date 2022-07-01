using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryInStockSIDBySkuResponse:JdObject{
      [JsonProperty("total")]
public 				int

             total
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("pageNo")]
public 				int

             pageNo
 { get; set; }
      [JsonProperty("serialNos")]
public 				List<string>

             serialNos
 { get; set; }
	}
}
