using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DrivingRegistrationItemEntity:JdObject{
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("orderStatus")]
public 				string

             orderStatus
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("phoneNumber")]
public 				string

             phoneNumber
 { get; set; }
      [JsonProperty("householdRegistration")]
public 				string

             householdRegistration
 { get; set; }
      [JsonProperty("idNumber")]
public 				string

             idNumber
 { get; set; }
      [JsonProperty("certificateIssuance")]
public 				string

             certificateIssuance
 { get; set; }
      [JsonProperty("liveAddress")]
public 				string

             liveAddress
 { get; set; }
      [JsonProperty("addressDetail")]
public 				string

             addressDetail
 { get; set; }
      [JsonProperty("drivingName")]
public 				string

             drivingName
 { get; set; }
      [JsonProperty("drivingAddress")]
public 				string

             drivingAddress
 { get; set; }
      [JsonProperty("drivingAddressee")]
public 				string

             drivingAddressee
 { get; set; }
      [JsonProperty("drivingPhone")]
public 				string

             drivingPhone
 { get; set; }
	}
}
