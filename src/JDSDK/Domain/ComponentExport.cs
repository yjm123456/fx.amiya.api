using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ComponentExport:JdObject{
      [JsonProperty("codeS")]
public 				string

             codeS
 { get; set; }
      [JsonProperty("nameS")]
public 				string

             nameS
 { get; set; }
	}
}
