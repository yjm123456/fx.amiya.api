using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RecommendSeedVO:JdObject{
      [JsonProperty("seedDisplayLable")]
public 				string

             seedDisplayLable
 { get; set; }
      [JsonProperty("seedType")]
public 				int

             seedType
 { get; set; }
      [JsonProperty("seedId")]
public 				string

             seedId
 { get; set; }
      [JsonProperty("isDefault")]
public 				int

             isDefault
 { get; set; }
      [JsonProperty("isChecked")]
public 				int

             isChecked
 { get; set; }
      [JsonProperty("groupType")]
public 				int

             groupType
 { get; set; }
	}
}
