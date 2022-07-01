using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EptWarecenterRecommendtempGetResponse:JdResponse{
      [JsonProperty("getrecommendtempbyid_result")]
public 				WareTempResult

                                                                                     getrecommendtempbyidResult
 { get; set; }
	}
}
