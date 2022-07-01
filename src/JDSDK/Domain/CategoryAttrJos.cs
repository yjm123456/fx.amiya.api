using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CategoryAttrJos:JdObject{
      [JsonProperty("categoryAttrId")]
public 				long

             categoryAttrId
 { get; set; }
      [JsonProperty("categoryId")]
public 				long

             categoryId
 { get; set; }
      [JsonProperty("attName")]
public 				string

             attName
 { get; set; }
      [JsonProperty("attrIndexId")]
public 				int

             attrIndexId
 { get; set; }
      [JsonProperty("inputType")]
public 				int

             inputType
 { get; set; }
      [JsonProperty("attributeType")]
public 				int

             attributeType
 { get; set; }
      [JsonProperty("attrFeatures")]
public 				List<string>

             attrFeatures
 { get; set; }
      [JsonProperty("categoryAttrGroup")]
public 				CategoryAttrGroupJos

             categoryAttrGroup
 { get; set; }
      [JsonProperty("attrValueList")]
public 				List<string>

             attrValueList
 { get; set; }
	}
}
