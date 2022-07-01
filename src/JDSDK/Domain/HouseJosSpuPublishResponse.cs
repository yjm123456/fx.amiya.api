using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseJosSpuPublishResponse:JdObject{
      [JsonProperty("sysCode")]
public 				string

             sysCode
 { get; set; }
      [JsonProperty("sysMsg")]
public 				string

             sysMsg
 { get; set; }
	}
}
