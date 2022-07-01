using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class KeywordGroup:JdObject{
      [JsonProperty("wgroup_id")]
public 				long

                                                                                     wgroupId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("search_num")]
public 				long

                                                                                     searchNum
 { get; set; }
      [JsonProperty("base_price")]
public 					double

                                                                                     basePrice
 { get; set; }
      [JsonProperty("avg_price")]
public 					double

                                                                                     avgPrice
 { get; set; }
      [JsonProperty("week_ctr")]
public 					double

                                                                                     weekCtr
 { get; set; }
	}
}
