using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class QueryOrderBasicInfoResponse:JdResponse{
      [JsonProperty("queryorderbasicinfo_result")]
public 				Result

                                                                                     queryorderbasicinfoResult
 { get; set; }
	}
}
