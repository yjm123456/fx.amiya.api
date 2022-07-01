using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class StockReadFindSkuStockResponse:JdResponse{
      [JsonProperty("skuStocks")]
public 				List<string>

             skuStocks
 { get; set; }
	}
}
