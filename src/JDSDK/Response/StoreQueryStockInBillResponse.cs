using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class StoreQueryStockInBillResponse:JdResponse{
      [JsonProperty("query_stock_in_result")]
public 				QueryStockInResult

                                                                                                                                                     queryStockInResult
 { get; set; }
	}
}
