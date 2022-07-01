using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CrowdVO:JdObject{
      [JsonProperty("crowdId")]
public 				long

             crowdId
 { get; set; }
      [JsonProperty("crowdName")]
public 				string

             crowdName
 { get; set; }
      [JsonProperty("crowdType")]
public 				int

             crowdType
 { get; set; }
      [JsonProperty("crowdNum")]
public 				int

             crowdNum
 { get; set; }
      [JsonProperty("isUsed")]
public 				int

             isUsed
 { get; set; }
      [JsonProperty("adGroupPrice")]
public 				string

             adGroupPrice
 { get; set; }
      [JsonProperty("crowdTabType")]
public 				int

             crowdTabType
 { get; set; }
      [JsonProperty("isNewTagCompose")]
public 				int

             isNewTagCompose
 { get; set; }
      [JsonProperty("sourceTypeCode")]
public 				int

             sourceTypeCode
 { get; set; }
      [JsonProperty("recommendCrowdType")]
public 				int

             recommendCrowdType
 { get; set; }
	}
}
