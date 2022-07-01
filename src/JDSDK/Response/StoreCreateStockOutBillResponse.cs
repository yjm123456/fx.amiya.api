using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class StoreCreateStockOutBillResponse:JdResponse{
      [JsonProperty("stockout_result")]
public 				StockOutResult

                                                                                     stockoutResult
 { get; set; }
	}
}
