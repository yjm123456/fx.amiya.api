using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RegionDTO:JdObject{
      [JsonProperty("province_id")]
public 				string

                                                                                     provinceId
 { get; set; }
      [JsonProperty("province")]
public 				string

             province
 { get; set; }
      [JsonProperty("city_id")]
public 				string

                                                                                     cityId
 { get; set; }
      [JsonProperty("city_name")]
public 				string

                                                                                     cityName
 { get; set; }
	}
}
