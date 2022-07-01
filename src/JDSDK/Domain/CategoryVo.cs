using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CategoryVo:JdObject{
      [JsonProperty("catId")]
public 				int

             catId
 { get; set; }
      [JsonProperty("parentId")]
public 				int

             parentId
 { get; set; }
      [JsonProperty("catName")]
public 				string

             catName
 { get; set; }
      [JsonProperty("catNameEn")]
public 				string

             catNameEn
 { get; set; }
      [JsonProperty("catLevel")]
public 				int

             catLevel
 { get; set; }
      [JsonProperty("sortOrder")]
public 				int

             sortOrder
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
