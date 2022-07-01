using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ImPopEvaluationlistGetResponse:JdResponse{
      [JsonProperty("Evaluation")]
public 				List<string>

             Evaluation
 { get; set; }
	}
}
