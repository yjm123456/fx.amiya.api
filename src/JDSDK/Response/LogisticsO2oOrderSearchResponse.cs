using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LogisticsO2oOrderSearchResponse:JdResponse{
      [JsonProperty("order")]
public 				OrderResponse

             order
 { get; set; }
	}
}
