using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class IllegalResponse:JdObject{
      [JsonProperty("data")]
public 				VenderJingcreditMainInfo

             data
 { get; set; }
      [JsonProperty("retCode")]
public 				string

             retCode
 { get; set; }
      [JsonProperty("retMsg")]
public 				string

             retMsg
 { get; set; }
	}
}
