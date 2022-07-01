using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopLocBroadbandOrderFindPageResponse:JdResponse{
      [JsonProperty("findpage_result")]
public 				PageResult

                                                                                     findpageResult
 { get; set; }
	}
}
