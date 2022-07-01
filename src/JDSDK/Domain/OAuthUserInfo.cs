using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OAuthUserInfo:JdObject{
      [JsonProperty("nickName")]
public 				string

             nickName
 { get; set; }
      [JsonProperty("imageUrl")]
public 				string

             imageUrl
 { get; set; }
      [JsonProperty("gendar")]
public 				int

             gendar
 { get; set; }
	}
}
