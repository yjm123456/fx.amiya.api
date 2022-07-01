using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseOrderVo:JdObject{
      [JsonProperty("userPhone")]
public 				string

             userPhone
 { get; set; }
      [JsonProperty("userName")]
public 				string

             userName
 { get; set; }
      [JsonProperty("city")]
public 				string

             city
 { get; set; }
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("spuTitle")]
public 				string

             spuTitle
 { get; set; }
      [JsonProperty("basePrice")]
public 				string

             basePrice
 { get; set; }
      [JsonProperty("disount")]
public 				string

             disount
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("payCodeStatus")]
public 				int

             payCodeStatus
 { get; set; }
      [JsonProperty("underLineOrderStatus")]
public 				int

             underLineOrderStatus
 { get; set; }
      [JsonProperty("createTime")]
public 				long

             createTime
 { get; set; }
      [JsonProperty("payType")]
public 				string

             payType
 { get; set; }
	}
}
