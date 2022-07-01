using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpOrderQueryOrderCustomsResponse:JdResponse{
      [JsonProperty("queryordercustoms_result")]
public 				List<string>

                                                                                     queryordercustomsResult
 { get; set; }
	}
}
