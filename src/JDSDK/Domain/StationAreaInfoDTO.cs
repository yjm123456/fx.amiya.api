using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StationAreaInfoDTO:JdObject{
      [JsonProperty("companyCode")]
public 				string

             companyCode
 { get; set; }
      [JsonProperty("stationCode")]
public 				string

             stationCode
 { get; set; }
      [JsonProperty("stationName")]
public 				string

             stationName
 { get; set; }
      [JsonProperty("stationAddress")]
public 				string

             stationAddress
 { get; set; }
      [JsonProperty("lat")]
public 				double

             lat
 { get; set; }
      [JsonProperty("lng")]
public 				double

             lng
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
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
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("fenceNum")]
public 				int

             fenceNum
 { get; set; }
      [JsonProperty("orgCode")]
public 				string

             orgCode
 { get; set; }
      [JsonProperty("fenceInfo")]
public 				List<string>

             fenceInfo
 { get; set; }
      [JsonProperty("areaCode")]
public 				string

             areaCode
 { get; set; }
      [JsonProperty("areaName")]
public 				string

             areaName
 { get; set; }
	}
}
