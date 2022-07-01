using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VcConfirmReceiveResultJosDto:JdObject{
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
      [JsonProperty("resultMessage")]
public 				string

             resultMessage
 { get; set; }
	}
}
