using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VenderBasicResult:JdObject{
      [JsonProperty("venderBasicVO")]
public 				VenderBasicVO

             venderBasicVO
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("errorCode")]
public 				string

             errorCode
 { get; set; }
      [JsonProperty("errorMsg")]
public 				string

             errorMsg
 { get; set; }
      [JsonProperty("totalNum")]
public 				int

             totalNum
 { get; set; }
	}
}
