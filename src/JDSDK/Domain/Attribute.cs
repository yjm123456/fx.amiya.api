using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Attribute:JdObject{
      [JsonProperty("attId")]
public 				int

             attId
 { get; set; }
      [JsonProperty("attName")]
public 				string

             attName
 { get; set; }
      [JsonProperty("groupId")]
public 				int

             groupId
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
	}
}
