using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class OrderStockoutResponse:JdResponse{
      [JsonProperty("orderstockout_result")]
public 				Result

                                                                                     orderstockoutResult
 { get; set; }
	}
}
