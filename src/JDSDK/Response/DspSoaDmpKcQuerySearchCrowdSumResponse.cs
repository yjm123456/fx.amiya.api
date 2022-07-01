using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspSoaDmpKcQuerySearchCrowdSumResponse:JdResponse{
      [JsonProperty("querySearchCrowdSum_result")]
public 				DspResult

                                                                                     querySearchCrowdSumResult
 { get; set; }
	}
}
