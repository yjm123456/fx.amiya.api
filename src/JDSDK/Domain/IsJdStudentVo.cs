using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class IsJdStudentVo:JdObject{
      [JsonProperty("code")]
public 				int

             code
 { get; set; }
      [JsonProperty("flag")]
public 				bool

             flag
 { get; set; }
      [JsonProperty("serverTime")]
public 				DateTime

             serverTime
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
	}
}
