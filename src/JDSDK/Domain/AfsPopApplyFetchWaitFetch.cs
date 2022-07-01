using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AfsPopApplyFetchWaitFetch:JdObject{
      [JsonProperty("afsApplyId")]
public 				int

             afsApplyId
 { get; set; }
      [JsonProperty("afsCategoryId")]
public 				int

             afsCategoryId
 { get; set; }
      [JsonProperty("wareId")]
public 				int

             wareId
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("afsServiceList")]
public 				List<string>

             afsServiceList
 { get; set; }
      [JsonProperty("afsApply")]
public 				AfsApplyWaitFetch

             afsApply
 { get; set; }
	}
}
