using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TrackShowResult:JdObject{
      [JsonProperty("ziyingShowResult")]
public 				List<string>

             ziyingShowResult
 { get; set; }
      [JsonProperty("thirdPsShowResult")]
public 				List<string>

             thirdPsShowResult
 { get; set; }
      [JsonProperty("daJiaDianInstallResult")]
public 				List<string>

             daJiaDianInstallResult
 { get; set; }
	}
}
