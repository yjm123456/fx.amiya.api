using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DeliveryVO:JdObject{
      [JsonProperty("adGroupId")]
public 				long

             adGroupId
 { get; set; }
      [JsonProperty("businessType")]
public 				int

             businessType
 { get; set; }
      [JsonProperty("campaignId")]
public 				long

             campaignId
 { get; set; }
      [JsonProperty("campaignType")]
public 				int

             campaignType
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("matchingType")]
public 				int

             matchingType
 { get; set; }
      [JsonProperty("pcPrice")]
public 				double

             pcPrice
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("skuUrl")]
public 				string

             skuUrl
 { get; set; }
      [JsonProperty("sourceType")]
public 				int

             sourceType
 { get; set; }
	}
}
