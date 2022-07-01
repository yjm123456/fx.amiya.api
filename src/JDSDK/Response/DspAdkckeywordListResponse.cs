using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspAdkckeywordListResponse:JdResponse{
      [JsonProperty("keywordListResult")]
public 				DspResult

             keywordListResult
 { get; set; }
	}
}
