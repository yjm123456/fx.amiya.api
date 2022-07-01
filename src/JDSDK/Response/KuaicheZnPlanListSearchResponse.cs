using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class KuaicheZnPlanListSearchResponse:JdResponse{
      [JsonProperty("plan_list_info")]
public 				QueryPlanReturnInfo

                                                                                                                     planListInfo
 { get; set; }
	}
}
