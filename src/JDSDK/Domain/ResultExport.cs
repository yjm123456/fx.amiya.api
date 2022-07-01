using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResultExport:JdObject{
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("data")]
public 				WaitAuditApplysPage

             data
 { get; set; }
      [JsonProperty("errMsg")]
public 				string

             errMsg
 { get; set; }
	}
}
