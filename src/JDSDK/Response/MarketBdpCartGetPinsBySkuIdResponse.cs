using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class MarketBdpCartGetPinsBySkuIdResponse:JdResponse{
      [JsonProperty("returnType")]
public 				List<string>

             returnType
 { get; set; }
	}
}
