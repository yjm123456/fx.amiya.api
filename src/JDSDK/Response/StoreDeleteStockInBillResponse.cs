using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class StoreDeleteStockInBillResponse:JdResponse{
      [JsonProperty("stock_in_delete_result")]
public 				StockInDeleteResult

                                                                                                                                                     stockInDeleteResult
 { get; set; }
	}
}
