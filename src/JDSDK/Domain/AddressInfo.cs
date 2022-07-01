using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AddressInfo:JdObject{
      [JsonProperty("provinceCode")]
public 				int

             provinceCode
 { get; set; }
      [JsonProperty("cityCode")]
public 				int

             cityCode
 { get; set; }
      [JsonProperty("countyCode")]
public 				int

             countyCode
 { get; set; }
      [JsonProperty("villageCode")]
public 				int

             villageCode
 { get; set; }
      [JsonProperty("detailAddress")]
public 				string

             detailAddress
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
	}
}
