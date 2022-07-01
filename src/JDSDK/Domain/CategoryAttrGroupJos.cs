using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CategoryAttrGroupJos:JdObject{
      [JsonProperty("groupId")]
public 				long

             groupId
 { get; set; }
      [JsonProperty("groupName")]
public 				string

             groupName
 { get; set; }
      [JsonProperty("attrGroupIndexId")]
public 				int

             attrGroupIndexId
 { get; set; }
      [JsonProperty("attrGroupfeatures")]
public 				List<string>

             attrGroupfeatures
 { get; set; }
	}
}
