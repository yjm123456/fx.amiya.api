using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FreightsResponseDTO:JdObject{
      [JsonProperty("resultCode")]
public 				byte

             resultCode
 { get; set; }
      [JsonProperty("resultMsg")]
public 				string

             resultMsg
 { get; set; }
      [JsonProperty("resultData")]
public 				FreightsDataDTO

             resultData
 { get; set; }
	}
}
