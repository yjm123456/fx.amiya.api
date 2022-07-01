using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspFeaturedusertagGetResponse:JdResponse{
      [JsonProperty("querylistusertag_result")]
public 				DspResult

                                                                                     querylistusertagResult
 { get; set; }
	}
}
