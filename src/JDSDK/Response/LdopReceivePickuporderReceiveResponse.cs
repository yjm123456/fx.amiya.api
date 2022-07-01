using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LdopReceivePickuporderReceiveResponse:JdResponse{
      [JsonProperty("receivepickuporder_result")]
public 				PickUpResultDTO

                                                                                     receivepickuporderResult
 { get; set; }
	}
}
