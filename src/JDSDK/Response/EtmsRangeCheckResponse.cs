using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EtmsRangeCheckResponse:JdResponse{
      [JsonProperty("resultInfo")]
public 				ResultInfoDTO

             resultInfo
 { get; set; }
	}
}
