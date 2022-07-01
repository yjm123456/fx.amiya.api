using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpExceptionQueryExceptionListResponse:JdResponse{
      [JsonProperty("josExceptionQueryResultList")]
public 				List<string>

             josExceptionQueryResultList
 { get; set; }
	}
}
