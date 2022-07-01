using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class UserInfoFBP:JdObject{
      [JsonProperty("fullname")]
public 				string

             fullname
 { get; set; }
      [JsonProperty("telephone")]
public 				string

             telephone
 { get; set; }
      [JsonProperty("mobile")]
public 				string

             mobile
 { get; set; }
      [JsonProperty("fullAddress")]
public 				string

             fullAddress
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
      [JsonProperty("provinceId")]
public 				string

             provinceId
 { get; set; }
      [JsonProperty("cityId")]
public 				string

             cityId
 { get; set; }
      [JsonProperty("countyId")]
public 				string

             countyId
 { get; set; }
      [JsonProperty("townId")]
public 				string

             townId
 { get; set; }
      [JsonProperty("consEmail")]
public 				string

             consEmail
 { get; set; }
      [JsonProperty("consPostCode")]
public 				string

             consPostCode
 { get; set; }
      [JsonProperty("desen_telephone")]
public 				string

                                                                                     desenTelephone
 { get; set; }
      [JsonProperty("desen_mobile")]
public 				string

                                                                                     desenMobile
 { get; set; }
	}
}
