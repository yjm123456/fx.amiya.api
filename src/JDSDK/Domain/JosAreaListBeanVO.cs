using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosAreaListBeanVO:JdObject{
      [JsonProperty("province_id")]
public 				long

                                                                                     provinceId
 { get; set; }
      [JsonProperty("province_name")]
public 				string

                                                                                     provinceName
 { get; set; }
      [JsonProperty("city_id")]
public 				long

                                                                                     cityId
 { get; set; }
      [JsonProperty("city_name")]
public 				string

                                                                                     cityName
 { get; set; }
      [JsonProperty("county_id")]
public 				long

                                                                                     countyId
 { get; set; }
      [JsonProperty("county_name")]
public 				string

                                                                                     countyName
 { get; set; }
      [JsonProperty("town_id")]
public 				long

                                                                                     townId
 { get; set; }
      [JsonProperty("town_name")]
public 				string

                                                                                     townName
 { get; set; }
      [JsonProperty("cod")]
public 				bool

             cod
 { get; set; }
	}
}
