using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JdAdressResponse:JdObject{
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
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
      [JsonProperty("countryId")]
public 				int

             countryId
 { get; set; }
      [JsonProperty("countryName")]
public 				string

             countryName
 { get; set; }
      [JsonProperty("townId")]
public 				int

             townId
 { get; set; }
      [JsonProperty("townName")]
public 				string

             townName
 { get; set; }
      [JsonProperty("lng")]
public 				double

             lng
 { get; set; }
      [JsonProperty("lat")]
public 				double

             lat
 { get; set; }
      [JsonProperty("reliability")]
public 				int

             reliability
 { get; set; }
      [JsonProperty("shipCodResult")]
public 				ShipCodResult

             shipCodResult
 { get; set; }
	}
}
