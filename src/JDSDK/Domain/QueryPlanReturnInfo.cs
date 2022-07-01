using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryPlanReturnInfo:JdObject{
      [JsonProperty("total_number")]
public 				int

                                                                                     totalNumber
 { get; set; }
      [JsonProperty("plan_list")]
public 				List<string>

                                                                                     planList
 { get; set; }
	}
}
