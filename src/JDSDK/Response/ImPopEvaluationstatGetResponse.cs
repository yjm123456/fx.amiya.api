using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ImPopEvaluationstatGetResponse:JdResponse{
      [JsonProperty("WaiterDailyEvaStat")]
public 				List<string>

             WaiterDailyEvaStat
 { get; set; }
	}
}
