using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpCoCancelLwbMainResponse:JdResponse{
      [JsonProperty("cancelLwbMain_result")]
public 				Result

                                                                                     cancelLwbMainResult
 { get; set; }
	}
}
