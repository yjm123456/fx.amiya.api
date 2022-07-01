using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ApplyDetailInfoExport:JdObject{
      [JsonProperty("afsApplyDetailId")]
public 				int

             afsApplyDetailId
 { get; set; }
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("afsDetailType")]
public 				int

             afsDetailType
 { get; set; }
      [JsonProperty("wareDescribe")]
public 				string

             wareDescribe
 { get; set; }
	}
}
