using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class UlMainResult:JdObject{
      [JsonProperty("ulNo")]
public 				string

             ulNo
 { get; set; }
      [JsonProperty("outUlNo")]
public 				string

             outUlNo
 { get; set; }
      [JsonProperty("status")]
public 				byte

             status
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("deliveryMode")]
public 				byte

             deliveryMode
 { get; set; }
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
      [JsonProperty("ulType")]
public 				byte

             ulType
 { get; set; }
      [JsonProperty("allowLackDest")]
public 				byte

             allowLackDest
 { get; set; }
      [JsonProperty("allowReturnDest")]
public 				byte

             allowReturnDest
 { get; set; }
      [JsonProperty("destMethod")]
public 				byte

             destMethod
 { get; set; }
      [JsonProperty("destReason")]
public 				byte

             destReason
 { get; set; }
      [JsonProperty("destCompNo")]
public 				string

             destCompNo
 { get; set; }
      [JsonProperty("receiver")]
public 				string

             receiver
 { get; set; }
      [JsonProperty("receiverPhone")]
public 				string

             receiverPhone
 { get; set; }
      [JsonProperty("email")]
public 				string

             email
 { get; set; }
      [JsonProperty("province")]
public 				string

             province
 { get; set; }
      [JsonProperty("city")]
public 				string

             city
 { get; set; }
      [JsonProperty("county")]
public 				string

             county
 { get; set; }
      [JsonProperty("town")]
public 				string

             town
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
      [JsonProperty("backEmail")]
public 				string

             backEmail
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("createUser")]
public 				string

             createUser
 { get; set; }
      [JsonProperty("ulItemResultList")]
public 				List<string>

             ulItemResultList
 { get; set; }
	}
}
