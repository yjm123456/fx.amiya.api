using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpOrderExtQueryOrderResponse:JdResponse{
      [JsonProperty("queryorder_result")]
public 				List<string>

                                                                                     queryorderResult
 { get; set; }
	}
}
