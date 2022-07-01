using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class StoreQueryStoreHouseRentlistResponse:JdResponse{
      [JsonProperty("query_stock_house_rent_result")]
public 				QueryStockHouseRentResult

                                                                                                                                                                                     queryStockHouseRentResult
 { get; set; }
	}
}
