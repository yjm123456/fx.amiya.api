using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SelectedKeywordInfo:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("plan_id")]
public 				long

                                                                                     planId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("wgroup_id")]
public 				string

                                                                                     wgroupId
 { get; set; }
      [JsonProperty("price")]
public 					string

             price
 { get; set; }
	}
}
