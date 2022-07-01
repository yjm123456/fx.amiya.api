using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspAdkckeywordRankSaveResponse:JdResponse{
      [JsonProperty("rankSaveResult")]
public 				DspResult

             rankSaveResult
 { get; set; }
	}
}
