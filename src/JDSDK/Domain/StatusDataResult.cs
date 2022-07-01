using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StatusDataResult:JdObject{
      [JsonProperty("code")]
public 				int

             code
 { get; set; }
      [JsonProperty("msg")]
public 				string

             msg
 { get; set; }
      [JsonProperty("requestId")]
public 				string

             requestId
 { get; set; }
      [JsonProperty("data")]
public 				IsvSmsAuditStatusOutVo

             data
 { get; set; }
	}
}
