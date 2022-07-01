using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class StoreCreateStockInBillResponse:JdResponse{
      [JsonProperty("stockin_result")]
public 				StockInResult

                                                                                     stockinResult
 { get; set; }
	}
}
