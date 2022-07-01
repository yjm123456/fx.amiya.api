using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderConsigneeResp:JdObject{
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("mobile")]
public 				string

             mobile
 { get; set; }
      [JsonProperty("provinceId")]
public 				int

             provinceId
 { get; set; }
      [JsonProperty("provinceName")]
public 				string

             provinceName
 { get; set; }
      [JsonProperty("cityId")]
public 				int

             cityId
 { get; set; }
      [JsonProperty("cityName")]
public 				string

             cityName
 { get; set; }
      [JsonProperty("countyId")]
public 				int

             countyId
 { get; set; }
      [JsonProperty("countyName")]
public 				string

             countyName
 { get; set; }
      [JsonProperty("townId")]
public 				int

             townId
 { get; set; }
      [JsonProperty("townName")]
public 				string

             townName
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
      [JsonProperty("zip")]
public 				string

             zip
 { get; set; }
      [JsonProperty("tel")]
public 				string

             tel
 { get; set; }
      [JsonProperty("email")]
public 				string

             email
 { get; set; }
      [JsonProperty("companyName")]
public 				string

             companyName
 { get; set; }
      [JsonProperty("idCard")]
public 				string

             idCard
 { get; set; }
	}
}
