using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ADGroupQuery:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("campaignId")]
public 				long

             campaignId
 { get; set; }
      [JsonProperty("feeStr")]
public 				string

             feeStr
 { get; set; }
      [JsonProperty("outerFeeStr")]
public 				string

             outerFeeStr
 { get; set; }
      [JsonProperty("inSearchFee")]
public 				long

             inSearchFee
 { get; set; }
      [JsonProperty("mobilePriceCoef")]
public 				double

             mobilePriceCoef
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("area")]
public 				string

             area
 { get; set; }
      [JsonProperty("areaId")]
public 				string

             areaId
 { get; set; }
      [JsonProperty("groupDirection")]
public 				string

             groupDirection
 { get; set; }
      [JsonProperty("position")]
public 				string

             position
 { get; set; }
      [JsonProperty("billingType")]
public 				int

             billingType
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
