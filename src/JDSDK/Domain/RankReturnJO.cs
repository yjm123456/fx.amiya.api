using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RankReturnJO:JdObject{
      [JsonProperty("response")]
public 				int

             response
 { get; set; }
      [JsonProperty("rank")]
public 				float

             rank
 { get; set; }
      [JsonProperty("description")]
public 				string

             description
 { get; set; }
      [JsonProperty("plan_date")]
public 				string

                                                                                     planDate
 { get; set; }
	}
}
