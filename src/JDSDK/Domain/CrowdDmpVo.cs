using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CrowdDmpVo:JdObject{
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
      [JsonProperty("crowdTypeLable")]
public 				string

             crowdTypeLable
 { get; set; }
      [JsonProperty("isUsed")]
public 				int

             isUsed
 { get; set; }
      [JsonProperty("adGroupPrice")]
public 				int

             adGroupPrice
 { get; set; }
	}
}
