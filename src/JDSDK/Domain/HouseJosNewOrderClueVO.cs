using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseJosNewOrderClueVO:JdObject{
      [JsonProperty("clueId")]
public 				long

             clueId
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("orderAmt")]
public 					string

             orderAmt
 { get; set; }
      [JsonProperty("orderPayTime")]
public 				DateTime

             orderPayTime
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
      [JsonProperty("houseId")]
public 				long

             houseId
 { get; set; }
      [JsonProperty("houseNo")]
public 				string

             houseNo
 { get; set; }
      [JsonProperty("layout")]
public 				int

             layout
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
      [JsonProperty("orderStatus")]
public 				int

             orderStatus
 { get; set; }
      [JsonProperty("venderName")]
public 				string

             venderName
 { get; set; }
      [JsonProperty("shopId")]
public 				long

             shopId
 { get; set; }
      [JsonProperty("shopName")]
public 				string

             shopName
 { get; set; }
	}
}
