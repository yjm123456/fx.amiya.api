using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VatInfo:JdObject{
      [JsonProperty("vatNo")]
public 				string

             vatNo
 { get; set; }
      [JsonProperty("addressRegIstered")]
public 				string

             addressRegIstered
 { get; set; }
      [JsonProperty("phoneRegIstered")]
public 				string

             phoneRegIstered
 { get; set; }
      [JsonProperty("depositBank")]
public 				string

             depositBank
 { get; set; }
      [JsonProperty("bankAccount")]
public 				string

             bankAccount
 { get; set; }
      [JsonProperty("companyName")]
public 				string

             companyName
 { get; set; }
      [JsonProperty("userName")]
public 				string

             userName
 { get; set; }
      [JsonProperty("userPhone")]
public 				string

             userPhone
 { get; set; }
      [JsonProperty("userProvinceId")]
public 				long

             userProvinceId
 { get; set; }
      [JsonProperty("userProvinceName")]
public 				string

             userProvinceName
 { get; set; }
      [JsonProperty("userCityId")]
public 				long

             userCityId
 { get; set; }
      [JsonProperty("userCityName")]
public 				string

             userCityName
 { get; set; }
      [JsonProperty("userAreaId")]
public 				long

             userAreaId
 { get; set; }
      [JsonProperty("userAreaName")]
public 				string

             userAreaName
 { get; set; }
      [JsonProperty("userTownId")]
public 				long

             userTownId
 { get; set; }
      [JsonProperty("userTownName")]
public 				string

             userTownName
 { get; set; }
      [JsonProperty("userAddress")]
public 				string

             userAddress
 { get; set; }
	}
}
