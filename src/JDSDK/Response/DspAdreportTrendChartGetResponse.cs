using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspAdreportTrendChartGetResponse:JdResponse{
      [JsonProperty("queryMinuteConcreteNew_result")]
public 				DspResult

                                                                                     queryMinuteConcreteNewResult
 { get; set; }
	}
}
