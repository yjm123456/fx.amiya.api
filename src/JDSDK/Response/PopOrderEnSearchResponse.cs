using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopOrderEnSearchResponse:JdResponse{
      [JsonProperty("searchorderinfo_result")]
public 				OrderListResult

                                                                                     searchorderinfoResult
 { get; set; }
	}
}
