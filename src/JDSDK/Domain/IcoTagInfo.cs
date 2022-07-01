using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class IcoTagInfo:JdObject{
      [JsonProperty("tagurl")]
public 				string

             tagurl
 { get; set; }
	}
}
