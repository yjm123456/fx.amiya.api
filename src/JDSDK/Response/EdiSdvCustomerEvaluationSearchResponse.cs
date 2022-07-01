using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EdiSdvCustomerEvaluationSearchResponse:JdResponse{
      [JsonProperty("evaluations")]
public 				List<string>

             evaluations
 { get; set; }
	}
}
