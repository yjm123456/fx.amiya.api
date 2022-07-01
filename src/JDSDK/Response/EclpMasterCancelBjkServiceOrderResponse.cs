using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpMasterCancelBjkServiceOrderResponse:JdResponse{
      [JsonProperty("cancelBjkServiceOrder_result")]
public 				BjkResult

                                                                                     cancelBjkServiceOrderResult
 { get; set; }
	}
}
