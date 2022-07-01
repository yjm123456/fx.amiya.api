using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TempCompletePage:JdObject{
      [JsonProperty("totalNum")]
public 				int

             totalNum
 { get; set; }
      [JsonProperty("tempCompleteList")]
public 				List<string>

             tempCompleteList
 { get; set; }
	}
}
