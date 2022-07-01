using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseJosXjkClueVO:JdObject{
      [JsonProperty("clueId")]
public 				long

             clueId
 { get; set; }
      [JsonProperty("freezeNo")]
public 				string

             freezeNo
 { get; set; }
      [JsonProperty("unFreezeNo")]
public 				string

             unFreezeNo
 { get; set; }
      [JsonProperty("activityName")]
public 				string

             activityName
 { get; set; }
      [JsonProperty("spuId")]
public 				long

             spuId
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("spuName")]
public 				string

             spuName
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("layout")]
public 				int

             layout
 { get; set; }
      [JsonProperty("nums")]
public 				int

             nums
 { get; set; }
      [JsonProperty("houseNo")]
public 				string

             houseNo
 { get; set; }
      [JsonProperty("freezeAmt")]
public 					string

             freezeAmt
 { get; set; }
      [JsonProperty("freezeStatus")]
public 				int

             freezeStatus
 { get; set; }
      [JsonProperty("acitvityTime")]
public 				DateTime

             acitvityTime
 { get; set; }
      [JsonProperty("payStatus")]
public 				int

             payStatus
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("contractName")]
public 				string

             contractName
 { get; set; }
      [JsonProperty("contractPhone")]
public 				string

             contractPhone
 { get; set; }
      [JsonProperty("userIdCard")]
public 				string

             userIdCard
 { get; set; }
      [JsonProperty("recommendName")]
public 				string

             recommendName
 { get; set; }
      [JsonProperty("recommendPhone")]
public 				string

             recommendPhone
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("shopId")]
public 				long

             shopId
 { get; set; }
      [JsonProperty("shopName")]
public 				string

             shopName
 { get; set; }
      [JsonProperty("venderName")]
public 				string

             venderName
 { get; set; }
	}
}
