using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspAdreportQueryaddailysumResponse:JdResponse{
      [JsonProperty("queryaddailysum_result")]
public 				DspResult

                                                                                     queryaddailysumResult
 { get; set; }
	}
}
