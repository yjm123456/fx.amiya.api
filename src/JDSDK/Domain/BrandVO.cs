using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BrandVO:JdObject{
      [JsonProperty("catId")]
public 				long

             catId
 { get; set; }
      [JsonProperty("brandName")]
public 				string

             brandName
 { get; set; }
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("cnName")]
public 				string

             cnName
 { get; set; }
      [JsonProperty("brandId")]
public 				long

             brandId
 { get; set; }
      [JsonProperty("enName")]
public 				string

             enName
 { get; set; }
	}
}
