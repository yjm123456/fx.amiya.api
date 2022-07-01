using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class JwPurchaseStockQueryStockResponse:JdResponse{
      [JsonProperty("querystock_result")]
public 				StockResponse

                                                                                     querystockResult
 { get; set; }
	}
}
