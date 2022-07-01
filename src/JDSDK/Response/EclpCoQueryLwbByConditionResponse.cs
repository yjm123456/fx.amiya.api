using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpCoQueryLwbByConditionResponse:JdResponse{
      [JsonProperty("coResult")]
public 				CoResult

             coResult
 { get; set; }
	}
}
