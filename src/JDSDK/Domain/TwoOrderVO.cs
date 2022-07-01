using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TwoOrderVO:JdObject{
      [JsonProperty("twoOrderId")]
public 				long

             twoOrderId
 { get; set; }
      [JsonProperty("orderStatus")]
public 				int

             orderStatus
 { get; set; }
      [JsonProperty("shippingAmount")]
public 				long

             shippingAmount
 { get; set; }
      [JsonProperty("orderTime")]
public 				DateTime

             orderTime
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
      [JsonProperty("payTime")]
public 				DateTime

             payTime
 { get; set; }
      [JsonProperty("returnAmount")]
public 				long

             returnAmount
 { get; set; }
      [JsonProperty("valueServiceAmount")]
public 				long

             valueServiceAmount
 { get; set; }
      [JsonProperty("actualAmount")]
public 				long

             actualAmount
 { get; set; }
      [JsonProperty("destCountryName")]
public 				string

             destCountryName
 { get; set; }
      [JsonProperty("consigneeName")]
public 				string

             consigneeName
 { get; set; }
      [JsonProperty("consigneeAddress")]
public 				string

             consigneeAddress
 { get; set; }
      [JsonProperty("consigneePhone")]
public 				string

             consigneePhone
 { get; set; }
      [JsonProperty("consigneeEmail")]
public 				string

             consigneeEmail
 { get; set; }
      [JsonProperty("zipCode")]
public 				string

             zipCode
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("extStr")]
public 				string

             extStr
 { get; set; }
      [JsonProperty("twoOrderItems")]
public 				TwoOrderItemVO[]

             twoOrderItems
 { get; set; }
      [JsonProperty("valueServiceItems")]
public 				TwoOrderValueServiceVO[]

             valueServiceItems
 { get; set; }
	}
}
