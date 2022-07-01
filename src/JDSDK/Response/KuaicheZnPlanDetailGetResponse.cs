using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class KuaicheZnPlanDetailGetResponse:JdResponse{
      [JsonProperty("plan_detail_info")]
public 				PlanDetailInfo

                                                                                                                     planDetailInfo
 { get; set; }
	}
}
