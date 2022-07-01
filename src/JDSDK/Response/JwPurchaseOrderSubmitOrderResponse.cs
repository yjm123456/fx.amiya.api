using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class JwPurchaseOrderSubmitOrderResponse:JdResponse{
      [JsonProperty("submitorder_result")]
public 				OrderSubmitResponse

                                                                                     submitorderResult
 { get; set; }
	}
}
