using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AfsServiceWaitFetch:JdObject{
      [JsonProperty("afsServiceId")]
public 				int

             afsServiceId
 { get; set; }
      [JsonProperty("afsApplyTime")]
public 				DateTime

             afsApplyTime
 { get; set; }
	}
}
