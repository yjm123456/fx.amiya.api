using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ExtTraceDto:JdObject{
      [JsonProperty("waybillCode")]
public 				string

             waybillCode
 { get; set; }
      [JsonProperty("operateDesc")]
public 				string

             operateDesc
 { get; set; }
      [JsonProperty("operateMessage")]
public 				string

             operateMessage
 { get; set; }
      [JsonProperty("operateName")]
public 				string

             operateName
 { get; set; }
      [JsonProperty("operateTime")]
public 				DateTime

             operateTime
 { get; set; }
	}
}
