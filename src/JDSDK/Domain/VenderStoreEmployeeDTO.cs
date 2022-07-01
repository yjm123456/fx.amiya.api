using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VenderStoreEmployeeDTO:JdObject{
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("storeId")]
public 				long

             storeId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("employeeId")]
public 				long

             employeeId
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("caccountId")]
public 				long

             caccountId
 { get; set; }
      [JsonProperty("openId")]
public 				long

             openId
 { get; set; }
      [JsonProperty("userName")]
public 				string

             userName
 { get; set; }
      [JsonProperty("imitateIp")]
public 				string

             imitateIp
 { get; set; }
      [JsonProperty("brandId")]
public 				long

             brandId
 { get; set; }
      [JsonProperty("bizId")]
public 				long

             bizId
 { get; set; }
      [JsonProperty("sourceType")]
public 				int

             sourceType
 { get; set; }
      [JsonProperty("employeeType")]
public 				int

             employeeType
 { get; set; }
      [JsonProperty("venderEmployeeId")]
public 				long

             venderEmployeeId
 { get; set; }
	}
}
