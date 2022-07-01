using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspAdreportQuerylocationResponse:JdResponse{
      [JsonProperty("querylocation_result")]
public 				DspResult

                                                                                     querylocationResult
 { get; set; }
	}
}
