using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PayoutShareInfo:JdObject{
      [JsonProperty("payoutShareInfoId")]
public 				int

             payoutShareInfoId
 { get; set; }
      [JsonProperty("payoutId")]
public 				int

             payoutId
 { get; set; }
      [JsonProperty("applyNum")]
public 				int

             applyNum
 { get; set; }
      [JsonProperty("shareMoney")]
public 					string

             shareMoney
 { get; set; }
      [JsonProperty("warePrice")]
public 					string

             warePrice
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("wareNum")]
public 				int

             wareNum
 { get; set; }
	}
}
