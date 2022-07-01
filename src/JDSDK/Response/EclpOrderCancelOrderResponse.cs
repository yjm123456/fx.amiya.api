using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpOrderCancelOrderResponse:JdResponse{
      [JsonProperty("cancelorder_result")]
public 				CancelResult

                                                                                     cancelorderResult
 { get; set; }
	}
}
