using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LogisticsReturnorderCancelResponse:JdResponse{
      [JsonProperty("process_result")]
public 				ProcessResult

                                                                                     processResult
 { get; set; }
	}
}
