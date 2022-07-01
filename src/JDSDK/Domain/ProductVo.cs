using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ProductVo:JdObject{
      [JsonProperty("skuid")]
public 				long

             skuid
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("onShelved")]
public 				DateTime

             onShelved
 { get; set; }
      [JsonProperty("onShelvedDateStr")]
public 				string

             onShelvedDateStr
 { get; set; }
      [JsonProperty("modifiedDate")]
public 					DateTime

             modifiedDate
 { get; set; }
      [JsonProperty("modifiedDateStr")]
public 				string

             modifiedDateStr
 { get; set; }
	}
}
