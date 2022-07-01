using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class StoreQueryStockOutBillResponse:JdResponse{
      [JsonProperty("query_stock_out_result")]
public 				QueryStockOutResult

                                                                                                                                                     queryStockOutResult
 { get; set; }
	}
}
