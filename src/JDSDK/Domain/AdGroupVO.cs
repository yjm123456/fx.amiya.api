using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AdGroupVO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("businessType")]
public 				int

             businessType
 { get; set; }
      [JsonProperty("campaignType")]
public 				int

             campaignType
 { get; set; }
      [JsonProperty("putType")]
public 				int

             putType
 { get; set; }
      [JsonProperty("campaignId")]
public 				long

             campaignId
 { get; set; }
      [JsonProperty("feeDecimal")]
public 				string

             feeDecimal
 { get; set; }
      [JsonProperty("adOptimize")]
public 				int

             adOptimize
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("campaignName")]
public 				string

             campaignName
 { get; set; }
	}
}
