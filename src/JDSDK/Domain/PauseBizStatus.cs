using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PauseBizStatus:JdObject{
      [JsonProperty("bizType")]
public 				int

             bizType
 { get; set; }
      [JsonProperty("bizStatus")]
public 				int

             bizStatus
 { get; set; }
	}
}
