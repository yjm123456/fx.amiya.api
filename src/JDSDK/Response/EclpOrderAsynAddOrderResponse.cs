using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class EclpOrderAsynAddOrderResponse:JdResponse{
      [JsonProperty("isReceivable")]
public 				bool

             isReceivable
 { get; set; }
	}
}
