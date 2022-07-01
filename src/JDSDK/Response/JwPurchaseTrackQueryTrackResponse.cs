using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class JwPurchaseTrackQueryTrackResponse:JdResponse{
      [JsonProperty("querytrack_result")]
public 				TrackResponse

                                                                                     querytrackResult
 { get; set; }
	}
}
