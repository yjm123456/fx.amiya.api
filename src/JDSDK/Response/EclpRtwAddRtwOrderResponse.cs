using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpRtwAddRtwOrderResponse:JdResponse{
      [JsonProperty("transportrtw_result")]
public 				RtwResult

                                                                                     transportrtwResult
 { get; set; }
	}
}
