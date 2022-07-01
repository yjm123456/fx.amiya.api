using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderSuitResp:JdObject{
      [JsonProperty("addMoney")]
public 					string

             addMoney
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("needMoney")]
public 					string

             needMoney
 { get; set; }
      [JsonProperty("promotionCode")]
public 				string

             promotionCode
 { get; set; }
      [JsonProperty("promotionMsg")]
public 				string

             promotionMsg
 { get; set; }
      [JsonProperty("suitName")]
public 				string

             suitName
 { get; set; }
      [JsonProperty("suitNum")]
public 				int

             suitNum
 { get; set; }
      [JsonProperty("suitType")]
public 				int

             suitType
 { get; set; }
      [JsonProperty("totalDiscount")]
public 					string

             totalDiscount
 { get; set; }
      [JsonProperty("totalOriginalPrice")]
public 					string

             totalOriginalPrice
 { get; set; }
      [JsonProperty("totalReward")]
public 					string

             totalReward
 { get; set; }
      [JsonProperty("virtualSkuId")]
public 				long

             virtualSkuId
 { get; set; }
	}
}
