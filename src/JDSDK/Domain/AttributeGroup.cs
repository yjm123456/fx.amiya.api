using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AttributeGroup:JdObject{
      [JsonProperty("groupId")]
public 				int

             groupId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("cid")]
public 				int

             cid
 { get; set; }
	}
}
