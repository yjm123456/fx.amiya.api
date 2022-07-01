using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CategoryAttrUnlimit:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("catId")]
public 				long

             catId
 { get; set; }
      [JsonProperty("orderSort")]
public 				int

             orderSort
 { get; set; }
      [JsonProperty("attributeType")]
public 				int

             attributeType
 { get; set; }
      [JsonProperty("inputType")]
public 				int

             inputType
 { get; set; }
      [JsonProperty("graphic")]
public 				string

             graphic
 { get; set; }
      [JsonProperty("isRequired")]
public 					bool

             isRequired
 { get; set; }
      [JsonProperty("features")]
public 				List<string>

             features
 { get; set; }
      [JsonProperty("attrValueList")]
public 				List<string>

             attrValueList
 { get; set; }
      [JsonProperty("attrGroup")]
public 				CategoryAttrGroupUnlimit

             attrGroup
 { get; set; }
	}
}
