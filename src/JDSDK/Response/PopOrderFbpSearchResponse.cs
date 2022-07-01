using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopOrderFbpSearchResponse:JdResponse{
      [JsonProperty("searchfbporderinfo_result")]
public 				OrderInfoResult

                                                                                     searchfbporderinfoResult
 { get; set; }
	}
}
