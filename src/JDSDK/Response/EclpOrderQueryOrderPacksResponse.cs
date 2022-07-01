using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpOrderQueryOrderPacksResponse:JdResponse{
      [JsonProperty("queryorderpacks_result")]
public 				List<string>

                                                                                     queryorderpacksResult
 { get; set; }
	}
}
