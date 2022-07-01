using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class QueryPurchaseProductResponse:JdResponse{
      [JsonProperty("querypurchaseproduct_result")]
public 				Result

                                                                                     querypurchaseproductResult
 { get; set; }
	}
}
