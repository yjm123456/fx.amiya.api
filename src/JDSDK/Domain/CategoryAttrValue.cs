using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CategoryAttrValue:JdObject{
      [JsonProperty("attrValueId")]
public 				long

             attrValueId
 { get; set; }
      [JsonProperty("attrValueIndexId")]
public 				int

             attrValueIndexId
 { get; set; }
      [JsonProperty("attrValue")]
public 				string

             attrValue
 { get; set; }
      [JsonProperty("attrValueFeatures")]
public 				List<string>

             attrValueFeatures
 { get; set; }
	}
}
