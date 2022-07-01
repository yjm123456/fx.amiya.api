using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AttributeValue:JdObject{
      [JsonProperty("valueId")]
public 				int

             valueId
 { get; set; }
      [JsonProperty("valueName")]
public 				string

             valueName
 { get; set; }
      [JsonProperty("attId")]
public 				int

             attId
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
	}
}
