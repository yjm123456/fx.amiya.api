using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderDataNotPayInfo:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("payment")]
public 				int

             payment
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("parentId")]
public 				long

             parentId
 { get; set; }
      [JsonProperty("orderCreated")]
public 				string

             orderCreated
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("userName")]
public 				string

             userName
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
      [JsonProperty("mobile")]
public 				string

             mobile
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("sendPay")]
public 				string

             sendPay
 { get; set; }
      [JsonProperty("itemList")]
public 				List<string>

             itemList
 { get; set; }
      [JsonProperty("provinceId")]
public 				int

             provinceId
 { get; set; }
      [JsonProperty("cityId")]
public 				int

             cityId
 { get; set; }
      [JsonProperty("countyId")]
public 				int

             countyId
 { get; set; }
      [JsonProperty("townId")]
public 				int

             townId
 { get; set; }
      [JsonProperty("orderMarkDesc")]
public 					Dictionary<string, object>

             orderMarkDesc
 { get; set; }
      [JsonProperty("desen_mobile")]
public 				string

                                                                                     desenMobile
 { get; set; }
      [JsonProperty("desen_phone")]
public 				string

                                                                                     desenPhone
 { get; set; }
	}
}
