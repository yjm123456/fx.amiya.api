using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaitAuditApplysPage:JdObject{
      [JsonProperty("applyInfoList")]
public 				List<string>

             applyInfoList
 { get; set; }
      [JsonProperty("totalNum")]
public 				int

             totalNum
 { get; set; }
	}
}
