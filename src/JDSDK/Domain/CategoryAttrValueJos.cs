using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CategoryAttrValueJos:JdObject{
      [JsonProperty("attributeId")]
public 				long

             attributeId
 { get; set; }
      [JsonProperty("categoryId")]
public 				long

             categoryId
 { get; set; }
      [JsonProperty("features")]
public 				List<string>

             features
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("indexId")]
public 				int

             indexId
 { get; set; }
      [JsonProperty("value")]
public 				string

             value
 { get; set; }
	}
}
