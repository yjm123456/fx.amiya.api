using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaybillAddress:JdObject{
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
      [JsonProperty("countryId")]
public 				int

             countryId
 { get; set; }
      [JsonProperty("countryName")]
public 				string

             countryName
 { get; set; }
      [JsonProperty("countrysideId")]
public 				int

             countrysideId
 { get; set; }
      [JsonProperty("countrysideName")]
public 				string

             countrysideName
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
	}
}
