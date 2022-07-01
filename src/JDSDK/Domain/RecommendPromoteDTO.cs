using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RecommendPromoteDTO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("campaignId")]
public 				long

             campaignId
 { get; set; }
      [JsonProperty("adGroupId")]
public 				long

             adGroupId
 { get; set; }
      [JsonProperty("retrievalType")]
public 				int

             retrievalType
 { get; set; }
      [JsonProperty("promoteRankEnable")]
public 				int

             promoteRankEnable
 { get; set; }
      [JsonProperty("promoteRankCoef")]
public 				int

             promoteRankCoef
 { get; set; }
      [JsonProperty("promoteRankType")]
public 				int

             promoteRankType
 { get; set; }
      [JsonProperty("campaignType")]
public 				int

             campaignType
 { get; set; }
      [JsonProperty("posPackageId")]
public 				long

             posPackageId
 { get; set; }
	}
}
