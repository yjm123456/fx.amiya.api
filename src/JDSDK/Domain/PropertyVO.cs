using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PropertyVO:JdObject{
      [JsonProperty("catId")]
public 				int

             catId
 { get; set; }
      [JsonProperty("propertyId")]
public 				int

             propertyId
 { get; set; }
      [JsonProperty("propertyName")]
public 				string

             propertyName
 { get; set; }
      [JsonProperty("propertyNameEn")]
public 				string

             propertyNameEn
 { get; set; }
      [JsonProperty("propertyType")]
public 				int

             propertyType
 { get; set; }
      [JsonProperty("required")]
public 				int

             required
 { get; set; }
      [JsonProperty("inputType")]
public 				int

             inputType
 { get; set; }
      [JsonProperty("nav")]
public 				int

             nav
 { get; set; }
	}
}
