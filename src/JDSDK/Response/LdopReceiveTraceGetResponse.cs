using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LdopReceiveTraceGetResponse:JdResponse{
      [JsonProperty("querytrace_result")]
public 				TraceQueryResultDTO

                                                                                     querytraceResult
 { get; set; }
	}
}
