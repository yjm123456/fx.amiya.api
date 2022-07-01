using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopOrderShipmentResponse:JdResponse{
      [JsonProperty("sopjosshipment_result")]
public 				OperatorResult

                                                                                     sopjosshipmentResult
 { get; set; }
	}
}
