using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpOrderQueryOrderResponse:JdResponse{
      [JsonProperty("queryorder_result")]
public 				OrderDetailResult

                                                                                     queryorderResult
 { get; set; }
	}
}
