using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspReportQueryAdDailySumResponse:JdResponse{
      [JsonProperty("querycampdailysum_result")]
public 				DspResult

                                                                                     querycampdailysumResult
 { get; set; }
	}
}
