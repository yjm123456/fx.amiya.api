using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class ImPopAskRateGetResponse:JdResponse{
      [JsonProperty("askRate")]
public 				double

             askRate
 { get; set; }
	}
}
