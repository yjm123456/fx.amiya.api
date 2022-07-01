using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class QueryPurchaseStockResponse:JdResponse{
      [JsonProperty("querystorestock_result")]
public 				Result

                                                                                     querystorestockResult
 { get; set; }
	}
}
