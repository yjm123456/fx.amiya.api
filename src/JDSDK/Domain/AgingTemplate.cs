using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AgingTemplate:JdObject{
      [JsonProperty("templateId")]
public 				long

             templateId
 { get; set; }
      [JsonProperty("templateName")]
public 				string

             templateName
 { get; set; }
	}
}
