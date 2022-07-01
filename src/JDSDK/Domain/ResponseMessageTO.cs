using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResponseMessageTO:JdObject{
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
      [JsonProperty("code")]
public 				int

             code
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
	}
}
