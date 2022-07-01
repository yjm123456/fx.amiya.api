using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopLocBroadbandOrderFindDetailResponse:JdResponse{
      [JsonProperty("finddetail_result")]
public 				Result

                                                                                     finddetailResult
 { get; set; }
	}
}
