using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspKcCampainListResponse:JdResponse{
      [JsonProperty("querylistbyparam_result")]
public 				DspResult

                                                                                     querylistbyparamResult
 { get; set; }
	}
}
