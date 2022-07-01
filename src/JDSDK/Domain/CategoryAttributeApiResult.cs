using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CategoryAttributeApiResult:JdObject{
      [JsonProperty("categoryPropertyList")]
public 				List<string>

             categoryPropertyList
 { get; set; }
      [JsonProperty("messegeCode")]
public 				string

             messegeCode
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
	}
}
