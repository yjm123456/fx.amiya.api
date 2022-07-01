using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspKcCampainStatusUpdateResponse:JdResponse{
      [JsonProperty("updatestatus_result")]
public 				DspResult

                                                                                     updatestatusResult
 { get; set; }
	}
}
