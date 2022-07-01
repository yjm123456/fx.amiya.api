using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpOrderGetOrderTrackMessageResponse:JdResponse{
      [JsonProperty("getOrderTrackMessage_result")]
public 				List<string>

                                                                                     getOrderTrackMessageResult
 { get; set; }
	}
}
