using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PurchaseOrderSelectInfosResponse:JdResponse{
      [JsonProperty("result")]
public 				GxOrderListResponse

             result
 { get; set; }
	}
}
