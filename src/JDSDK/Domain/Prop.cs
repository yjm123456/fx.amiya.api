using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Prop:JdObject{
      [JsonProperty("attrValueAlias")]
public 				string

             attrValueAlias
 { get; set; }
      [JsonProperty("attrId")]
public 				string

             attrId
 { get; set; }
      [JsonProperty("attrValues")]
public 				string

             attrValues
 { get; set; }
	}
}
